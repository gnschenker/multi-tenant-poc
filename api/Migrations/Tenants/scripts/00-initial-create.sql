CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE tenants (
    id text NOT NULL,
    key text NULL,
    description text NULL,
    created_on timestamp without time zone NOT NULL,
    CONSTRAINT pk_tenants PRIMARY KEY (id)
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191122145309_InitialCreate', '2.2.6-servicing-10079');

