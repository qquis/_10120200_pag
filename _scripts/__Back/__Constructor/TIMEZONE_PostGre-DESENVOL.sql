ALTER SYSTEM SET timezone = 'America/Sao_Paulo';
-- Ou para versões mais novas
ALTER SYSTEM SET TimeZone = 'America/Sao_Paulo';

SELECT pg_reload_conf();
