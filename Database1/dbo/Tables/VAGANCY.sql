CREATE TABLE [dbo].[VAGANCY] (
    [VAGANCY_ID]      INT             IDENTITY (1, 1) NOT NULL,
    [VG_TITLE]        VARCHAR (80)    NOT NULL,
    [CPY_ID]          INT             NOT NULL,
    [VG_DATE_FINALLY] DATE            NULL,
    [VG_OBS]          VARCHAR (MAX)   NOT NULL,
    [VG_STATUS]       CHAR (1)        NULL,
    [VG_DATECREATE]   DATE            NULL,
    [VG_VALUE]        DECIMAL (18, 2) NULL,
    [USS_ID]          INT             NULL,
    PRIMARY KEY CLUSTERED ([VAGANCY_ID] ASC)
);

