FROM postgres:16

ENV POSTGRES_USER=postgres
ENV POSTGRES_PASSWORD=postgres

COPY ["Databases/InitDb.sql", "/docker-entrypoint-initdb.d/"]

ENTRYPOINT ["docker-entrypoint.sh"]

CMD ["postgres"] 
