-- -----------------------------------------------------
-- Schema miniErp
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS miniErp DEFAULT CHARACTER SET utf8;

USE miniErp;

SET FOREIGN_KEY_CHECKS = 0;

-- -----------------------------------------------------
-- miniErp.partner
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS miniErp.partner (
  `partnerId`       char(36)         NOT NULL default 'uuid()' COMMENT 'Identificador do registro',
  `name`            varchar(100)     NOT NULL                  COMMENT 'Nome do parceiro',
  `document`        varchar(20)      NOT NULL                  COMMENT 'Documento do parceiro',
  `situation`       int              NOT NULL default 0        COMMENT 'Situação do parceiro',
  `status`          int              NOT NULL default 1        COMMENT 'Status do parceiro',
  `partnerCode`     varchar(50)      NOT NULL                  COMMENT 'Codigo interno do parceiro',
  `creationDate`    datetime         NOT NULL default NOW()    COMMENT 'Data de criação do registro',
  `updatedDate`     timestamp        NOT NULL default current_timestamp on update current_timestamp COMMENT 'Data de atualização do registro',
  PRIMARY KEY (`partnerId`)
)ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;


SET FOREIGN_KEY_CHECKS = 1;
