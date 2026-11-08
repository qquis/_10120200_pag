-- Active: 1777038659657@@172.17.0.166@5432@oxan
SELECT motorista_key 
FROM roteiro_entrega 
WHERE data_criacao >= CURRENT_DATE - 100
group by motorista_key