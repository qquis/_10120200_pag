
do $$
declare vnome_tabela varchar(100) = 'tbfc_regrafiscal_nfce_produto';
begin 

	
	drop table if exists tmp_script_class
	;
	
	create temporary table tmp_script_class (bloco smallint, linha smallint, dado varchar(200))
	;

	insert into tmp_script_class (bloco, linha, dado) 
		select 0, 0, 'import { clsTools, clsBase} from ' || '''' || '../../../model/modelbase' || ''''  
	;


	insert into tmp_script_class (bloco, linha, dado) 
		select 0, 1, 'export default class ' || vnome_tabela || ' extends clsBase {'
	;

	

	insert into tmp_script_class (bloco, linha, dado) 		
	select 1, 0, repeat(' ', 8) || case data_type 
		   when 'character varying' then column_name || ': string'
		   when 'integer' then column_name || ': number'
		   when 'timestamp without time zone' then column_name || ': Date'
		   when 'date' then column_name || ': Date'
		   when 'numeric' then column_name || ': number'
		   when 'smallint' then column_name || ': number'
		   when 'character' then column_name  
		end
	--column_name, data_type 
	from information_schema.columns where table_name = vnome_tabela
	order by column_name asc 


	;
	-- inicialize
	insert into tmp_script_class (bloco, linha, dado)  		
		select 2, 0, repeat(' ', 8) ||'constructor() {'

	;
	insert into tmp_script_class (bloco, linha, dado) 	
		select 3, 0 , repeat(' ', 12) ||'super()'

	;
		
	insert into tmp_script_class (bloco, linha, dado) 
	select 4, 0, repeat(' ', 12) || case data_type 
		   when 'character varying' then 'this.' || column_name || '= ' || '''' || ''''
		   when 'integer' then 'this.' || column_name || '= 0'
		   when 'timestamp without time zone' then 'this.' || column_name || '= this.__defaultDateNow '
		   when 'date' then 'this.' || column_name || '= this.__defaultDateNow '
		   when 'numeric' then 'this.' || column_name || '= 0 '
		   when 'smallint' then 'this.' || column_name || '= 0 '	
		   when 'character' then 'this.'  || column_name || '= ' || '''' || ''''	   
		end
	--column_name, data_type 
	from information_schema.columns where table_name = vnome_tabela
	order by table_name, column_name asc 	

	;
	insert into tmp_script_class (bloco, linha, dado)  		
		select 4, 1, repeat(' ', 8) ||'}'

	

	;
	insert into tmp_script_class (bloco, linha, dado) 
	select 5, 0, repeat(' ', 8) || 'async binding(item: any): Promise<void> {'
	union select 5, 1, repeat(' ', 12) || '    if (item) {'
	union select 5, 2, repeat(' ', 16) ||case data_type 
		   when 'character varying' then 'this.' || column_name || ' = item?.' || column_name
		   when 'integer' then 'this.' || column_name || ' = item?.' || column_name
		   when 'timestamp without time zone' then 'this.' || column_name || ' = this.myTools._datemomentDatStrToDate(item?.' || column_name || ',`YYYY-MM-DD HH:mm:ss`)'
		   when 'date' then 'this.' || column_name || ' = item?.' || column_name
		   when 'numeric' then 'this.' || column_name || ' = item?.' || column_name
		   when 'smallint' then 'this.' || column_name || ' = item?.' || column_name
		   when 'character' then 'this.' || column_name || ' = item?.' || column_name
		end
	--column_name, data_type 
	from information_schema.columns where table_name = vnome_tabela
	
	union select 5, 3, '        }'
	union select 5, 4, '    }'
	order by 1, 2 asc
	;


	insert into tmp_script_class (bloco, linha, dado)  		
	select 10, 1, '}'
	;
end $$	
;
select dado from tmp_script_class order by bloco, linha, dado asc


