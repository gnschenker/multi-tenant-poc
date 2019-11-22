CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE blogs (
    id uuid NOT NULL,
    name text NULL,
    title text NULL,
    description text NULL,
    created_on timestamp without time zone NOT NULL,
    CONSTRAINT pk_blogs PRIMARY KEY (id)
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20191122145714_InitialCreate', '2.2.6-servicing-10079');

