-- ---------------------------------------------------------------------------------------------------
-- PRE-USO
-- --------

INSERT INTO PREU_PREUSE(PreUseCheckDescription, PreUsePerfomDescription, PreUseImage, PreUseStatus)
VALUES
('','','',1)
GO
INSERT INTO PREU_PREUSE_CATEGORYTOOL(CategoryToolCode, PreUseId, PreUseCategoryToolOrder)
VALUES
('',0,1)
GO
-- SELECT MAX(PreUseId) FROM PREU_PREUSE

-- ---------------------------------------------------------------------------------------------------
-- INSPECCIÓN
-- ----------

INSERT INTO PREU_INSPECTION_FORMAT(InspectionFormatCheckDescription, InspectionFormatPerfomDescription, 
InspectionFormatImage, InspectionFormatStatus)
VALUES
('','','',1)
GO
INSERT INTO PREU_INSPECTIONFORMAT_CATEGORYTOOL(CategoryToolCode, InspectionFormatId, InspectionFormatCatOrder)
VALUES
('',0,1)
GO

-- SELECT MAX(InspectionFormatId) FROM PREU_INSPECTION_FORMAT

-- ---------------------------------------------------------------------------------------------------