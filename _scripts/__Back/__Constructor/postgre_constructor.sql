/* JS */
	-- DECLARE 
	select column_name, data_type, case data_type 
		   when 'character varying' then column_name || ': string'
		   when 'integer' then column_name || ': number'
		   when 'timestamp without time zone' then column_name || ': Date'
		   when 'date' then column_name || ': Date'
		   when 'numeric' then column_name || ': number'
		   when 'smallint' then column_name || ': number'
		   when 'character' then column_name  
		end
	--column_name, data_type 
	from information_schema.columns where table_name = 'tbrh_tipo_contrato'
	order by column_name asc 

	-- inicialize
	select table_name, column_name, data_type, case data_type 
		   when 'character varying' then 'this.' || column_name || '= ' || '''' || ''''
		   when 'integer' then 'this.' || column_name || '= 0'
		   when 'timestamp without time zone' then 'this.' || column_name || '= this.__defaultDateNow '
		   when 'date' then 'this.' || column_name || '= this.__defaultDateNow '
		   when 'numeric' then 'this.' || column_name || '= 0 '
		   when 'smallint' then 'this.' || column_name || '= 0 '	
		   when 'character' then 'this.'  || column_name || '= ' || '''' || ''''	   
		end
	--column_name, data_type 
	from information_schema.columns where table_name like 'tbrh_tipo_contrato'
	order by table_name, column_name asc 	

	-- Binding 
	
	select 0, 'async binding(item: any): Promise<void> {'
	union select 1, '    if (item) {'
	union select 2,	case data_type 
		   when 'character varying' then 'this.' || column_name || ' = item?.' || column_name
		   when 'integer' then 'this.' || column_name || ' = item?.' || column_name
		   when 'timestamp without time zone' then 'this.' || column_name || ' = myTools._dataMomentoStrToDate(item?.' || column_name || ',`YYYY-MM-DD HH:mm:ss`)'
		   when 'date' then 'this.' || column_name || ' = item?.' || column_name
		   when 'numeric' then 'this.' || column_name || ' = item?.' || column_name
		   when 'smallint' then 'this.' || column_name || ' = item?.' || column_name
		   when 'character' then 'this.' || column_name || ' = item?.' || column_name
		end
	--column_name, data_type 
	from information_schema.columns where table_name like 'tbrh_tipo_contrato'
	
	union select 3, '        }'
	union select 4, '    }'
	order by 1, 2 asc