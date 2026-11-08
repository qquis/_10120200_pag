---select * from tbprodutobluesoft limit 10

do $$
begin 



create TEMPORARY TABLE tmp_venda_produto 
                                (		pr_cdproduto		varchar(10)
									,	ano 				varchar(4)
									,	mes01_valor			numeric(13,2)
									,	mes01_custo 		numeric(13,2)                                    
									,	mes01_volume 		numeric(17,2)
									,	mes01_margem    	numeric(7,2)
									,	mes01_participacao	numeric(7,1)
									,	mes02_valor			numeric(13,2)
									,	mes02_custo 		numeric(13,2)                                    
									,	mes02_volume 		numeric(17,2)
									,	mes02_margem    	numeric(7,2)
									,	mes02_participacao	numeric(7,1)
                                    ,	mes03_valor			numeric(13,2)   
                                    ,	mes03_custo 		numeric(13,2)                                    
                                    ,	mes03_volume 		numeric(17,2)
                                    ,	mes03_margem    	numeric(7,2)
                                    ,	mes03_participacao	numeric(7,1)
                                    ,	mes04_valor			numeric(13,2)
                                    ,	mes04_custo 		numeric(13,2)                                    
                                    ,	mes04_volume 		numeric(17,2)
                                    ,	mes04_margem    	numeric(7,2)
                                    ,	mes04_participacao	numeric(7,1)    
                                    ,	mes05_valor			numeric(13,2)
                                    ,	mes05_custo 		numeric(13,2)                                    
                                    ,	mes05_volume 		numeric(17,2)
                                    ,	mes05_margem    	numeric(7,2)
                                    ,	mes05_participacao	numeric(7,1)
                                    ,	mes06_valor			numeric(13,2)
                                    ,	mes06_custo 		numeric(13,2)           
                                    ,	mes06_volume 		numeric(17,2)           
                                    ,	mes06_margem    	numeric(7,2)
                                    ,	mes06_participacao	numeric(7,1)
                                    ,	mes07_valor			numeric(13,2)
                                    ,	mes07_custo 		numeric(13,2)
                                    ,	mes07_volume 		numeric(17,2)
                                    ,	mes07_margem    	numeric(7,2)
                                    ,	mes07_participacao	numeric(7,1)
                                    ,	mes08_valor			numeric(13,2)
                                    ,	mes08_custo 		numeric(13,2)                                    
                                    ,	mes08_volume 		numeric(17,2)
                                    ,	mes08_margem    	numeric(7,2)
                                    ,	mes08_participacao	numeric(7,1)
                                    ,	mes09_valor			numeric(13,2)
                                    ,	mes09_custo 		numeric(13,2)                                    
                                    ,	mes09_volume 		numeric(17,2)
                                    ,	mes09_margem    	numeric(7,2)
                                    ,	mes09_participacao	numeric(7,1)
                                    ,	mes10_valor			numeric(13,2)
                                    ,	mes10_custo 		numeric(13,2)
                                    ,	mes10_volume 		numeric(17,2)
                                    ,	mes10_margem    	numeric(7,2)
                                    ,	mes10_participacao	numeric(7,1)
                                    ,	mes11_valor			numeric(13,2)
                                    ,	mes11_custo 		numeric(13,2)
                                    ,	mes11_volume 		numeric(17,2)
                                    ,	mes11_margem    	numeric(7,2)
                                    ,	mes11_participacao	numeric(7,1)
                                    ,	mes12_valor			numeric(13,2)
                                    ,	mes12_custo 		numeric(13,2)                                    
                                    ,	mes12_volume 		numeric(17,2)
                                    ,	mes12_margem    	numeric(7,2)
                                    ,	mes12_participacao	numeric(7,1)    


								)



         



end$$	

;