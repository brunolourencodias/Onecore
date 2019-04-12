﻿CREATE TABLE [dbo].[REGISTERCLIENT] (
    [RST_ID]        INT          IDENTITY (1, 1) NOT NULL,
    [USS_ID]        INT          NULL,
    [RST_NAME]      VARCHAR (80) NOT NULL,
    [RST_GENRE]     CHAR (1)     NOT NULL,
    [RST_DATEBIRTH] DATE         NULL,
    [RST_DOCUMENT]  VARCHAR (11) NOT NULL,
    PRIMARY KEY CLUSTERED ([RST_ID] ASC)
);
