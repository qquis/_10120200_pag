SELECT							0 AS linha
							,	'RecordType;Distributor code;Client code;Client Federal ID;Client name;Client status;Salesman code;Salesman name;SalesmanType'
				
				UNION
SELECT
      ROW_NUMBER() OVER (ORDER BY a.cdparticipante) AS linha
    , 'DIALCLIENT01BR'
      || ';'
      || '40870'
      || ';'
      || COALESCE(a.cdparticipante, 1)::VARCHAR(10)
      || ';'
      || LEFT(COALESCE(TRUNC(a.cpf_cnpj::NUMERIC)::VARCHAR(14), '57895328000130'), 14)
      || ';'
      || COALESCE(LEFT(ps.nome_razao, 40), 'OXAN ATACADISTA LTDA')
      || ';'
      || COALESCE(CASE ps.bluesoftclientestatus WHEN 0 THEN 'Closed' ELSE 'Active' END, 'Closed')
      || ';'
      -- || COALESCE(LEFT(REPLACE(pv.erptargetcd_vend, 'V', ''), 5), '236')
      || COALESCE(LEFT(psv.cdpessoabluesoft::TEXT, 5), '2046')
      || ';'
      || COALESCE(LEFT(psv.nome_razao, 40), 'FRANCISCO EDUARDO DA SILVA')
      || ';'
      || 'COMUM' AS coluna
----------------------------------------------------------------------------------------------------------------------------------------------
FROM        tbparticipante a
INNER JOIN  tbpessoabluesoft ps  ON ps.cdpessoabluesoft = a.cdpessoabluesoft
LEFT JOIN   tbparticipante   pv  ON pv.cdpessoabluesoft = ps.cdpessoabluesoft_vendedor
                                AND ps.cdpessoabluesoft_vendedor <> 0
LEFT JOIN   tbpessoabluesoft psv ON psv.cdpessoabluesoft = pv.cdpessoabluesoft
WHERE 1 = 1
AND (
        a.cdparticipante IN (
            SELECT x.cdparticipantecliente
            FROM   tbinterfacefaturamentoinfoitem x
            WHERE  x.datafaturamento >= current_date - 360
            AND    x.datafaturamento <= current_date
            AND    x.seqinterface = 1
        )
     OR (ps.bluesoftclientestatus = 1 AND COALESCE(ps.cdgrupoeconomico, 0) > 0)
    )

order by 1    