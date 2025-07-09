SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--计算地球上两个坐标点（经度，纬度）之间距离sql函数
--作者：lordbaby
--整理：www.aspbc.com
CREATE FUNCTION [dbo].[GetDistance](@LatBegin REAL, @LngBegin REAL, @LatEnd REAL, @LngEnd REAL) RETURNS FLOAT
  AS
BEGIN
  --距离(千米)
  DECLARE @Distance REAL
  DECLARE @EARTH_RADIUS REAL
  SET @EARTH_RADIUS = 6378.137 
  DECLARE @RadLatBegin REAL,@RadLatEnd REAL,@RadLatDiff REAL,@RadLngDiff REAL
  SET @RadLatBegin = @LatBegin *PI()/180.0 
  SET @RadLatEnd = @LatEnd *PI()/180.0 
  SET @RadLatDiff = @RadLatBegin - @RadLatEnd 
  SET @RadLngDiff = @LngBegin *PI()/180.0 - @LngEnd *PI()/180.0  
  SET @Distance = 2 *ASIN(SQRT(POWER(SIN(@RadLatDiff/2), 2)+COS(@RadLatBegin)*COS(@RadLatEnd)*POWER(SIN(@RadLngDiff/2), 2)))
  SET @Distance = @Distance * @EARTH_RADIUS 
  --SET @Distance = Round(@Distance * 10000) / 10000 
  RETURN @Distance
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		用户角色权限
-- Create date: 2020年6月19日 15:26:33
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FN_RolePermissionDetailGetStrName](@user_id Decimal(9),@role_type nvarchar(20))

RETURNS NVARCHAR(500)
AS
BEGIN
DECLARE @ret NVARCHAR(500)
    SET @ret = ''
    SELECT  @ret = @ret + '|' + RTRIM(SYS_ROLE.ROLE_NAME)
    FROM    SYS_USER_ROLE INNER JOIN SYS_ROLE ON SYS_USER_ROLE.ROLE_NO = SYS_ROLE.ROLE_NO
    WHERE   SYS_USER_ROLE.USER_ID = @user_id AND SYS_ROLE.ROLE_TYPE = @role_type AND SYS_ROLE.IS_ENABLED = 1 AND SYS_ROLE.IS_ADMIN = 0
    SET @ret = CASE WHEN LEN(@ret) > 0 THEN STUFF(@ret, 1, 1, '')
                    ELSE @ret
               END
	RETURN @ret 
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		用户操作权限验证
-- Create date: 2020年6月19日 15:26:28
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FN_OperationalRights](@uid Decimal(9),@operation_code nvarchar(20))

RETURNS int
AS
BEGIN
DECLARE @authorization int
DECLARE @roletype nvarchar(20)
DECLARE @userid Decimal(9)
	SET @authorization = 0;
	SELECT @userid = SYS_USER.USER_ID, @roletype = SYS_USER.ROLE_TYPE FROM SYS_USER WHERE SYS_USER.USER_ID = @uid AND SYS_USER.IS_AVAILABLE = 1
		SELECT @authorization = COUNT(SYS_PERM.FUNCTION_ID)
		FROM SYS_PERM SYS_PERM 
		LEFT JOIN SYS_FUNCTION SYS_FUNCTION ON SYS_PERM.FUNCTION_ID = SYS_FUNCTION.FUNCTION_ID 
		LEFT JOIN SYS_ROLE SYS_ROLE ON SYS_PERM.ROLE_NO = SYS_ROLE.ROLE_NO 
		LEFT JOIN SYS_WEB_MODULE SYS_WEB_MODULE ON SYS_FUNCTION.MODULE_CODE = SYS_WEB_MODULE.MODULE_CODE 
		WHERE SYS_PERM.ROLE_NO IN (SELECT ROLE_NO FROM SYS_USER_ROLE WHERE SYS_USER_ROLE.USER_ID = @userid AND SYS_WEB_MODULE.IS_AVAILABLE = 1 AND SYS_WEB_MODULE.MODULE_TYPE = @roletype) 
		AND SYS_PERM.FUNCTION_ID = @operation_code GROUP BY SYS_PERM.FUNCTION_ID 
		IF @authorization IS NULL
			SET @authorization = 0;
	RETURN @authorization 
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		用户权限验证
-- Create date: 2020年7月28日 15:15:53
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FN_UserRights](@token nvarchar(50),@funid nvarchar(20))

RETURNS int
AS
BEGIN
DECLARE @authorization int
DECLARE @roletype nvarchar(20)
DECLARE @userid Decimal(9)
	SET @authorization = 0;
	SELECT @userid = SYS_USER.USER_ID, @roletype = SYS_USER.ROLE_TYPE FROM SYS_USER WHERE SYS_USER.IS_AVAILABLE = 1 AND 
		SYS_USER.USER_ID IN (SELECT USER_DEVICE.USER_ID FROM USER_DEVICE WHERE USER_DEVICE.DEVICE_TYPE = 0 AND ACTIVE_TIME < GETDATE() AND EXPIRED_TIME > GETDATE() AND USER_DEVICE.TOKEN = @token)
		IF @userid IS NOT NULL
		BEGIN
			SELECT @authorization = COUNT(SYS_PERM.FUNCTION_ID)
			FROM SYS_PERM SYS_PERM 
			LEFT JOIN SYS_FUNCTION SYS_FUNCTION ON SYS_PERM.FUNCTION_ID = SYS_FUNCTION.FUNCTION_ID 
			LEFT JOIN SYS_ROLE SYS_ROLE ON SYS_PERM.ROLE_NO = SYS_ROLE.ROLE_NO 
			LEFT JOIN SYS_WEB_MODULE SYS_WEB_MODULE ON SYS_FUNCTION.MODULE_CODE = SYS_WEB_MODULE.MODULE_CODE 
			WHERE SYS_PERM.ROLE_NO IN (SELECT ROLE_NO FROM SYS_USER_ROLE WHERE SYS_USER_ROLE.USER_ID = @userid AND SYS_WEB_MODULE.IS_AVAILABLE = 1 AND SYS_WEB_MODULE.MODULE_TYPE = @roletype) 
			AND SYS_PERM.FUNCTION_ID = @funid GROUP BY SYS_PERM.FUNCTION_ID 
			IF @authorization IS NULL
			BEGIN
				SET @authorization = 0;
			END
		END
		ELSE
		BEGIN
			SET @authorization = 0;
		END
	RETURN @authorization 
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		权限数组
-- Create date: 2020年8月4日 15:55:25
-- Description:	
-- =============================================
CREATE FUNCTION FN_PermissionArray(@user_id Decimal(9),@role_type nvarchar(20))

RETURNS NVARCHAR(500)
AS
BEGIN
DECLARE @ret NVARCHAR(4000)
    SET @ret = ''
	SELECT @ret = @ret + ',' + RTRIM((SYS_PERM.FUNCTION_ID)) FROM SYS_PERM SYS_PERM 
	LEFT JOIN SYS_FUNCTION SYS_FUNCTION ON SYS_PERM.FUNCTION_ID = SYS_FUNCTION.FUNCTION_ID 
	LEFT JOIN SYS_ROLE SYS_ROLE ON SYS_PERM.ROLE_NO = SYS_ROLE.ROLE_NO 
	LEFT JOIN SYS_WEB_MODULE SYS_WEB_MODULE ON SYS_FUNCTION.MODULE_CODE = SYS_WEB_MODULE.MODULE_CODE 
	WHERE SYS_PERM.ROLE_NO IN (select ROLE_NO from SYS_USER_ROLE where SYS_USER_ROLE.USER_ID = @user_id AND SYS_WEB_MODULE.MODULE_TYPE = @role_type AND SYS_WEB_MODULE.IS_AVAILABLE = 1 ) 
	GROUP BY   SYS_PERM.FUNCTION_ID  ORDER BY  MAX(SYS_WEB_MODULE.SORT_NO),MAX(SYS_FUNCTION.MODULE_CODE),MAX(SYS_FUNCTION.FUNCTION_CODE)   
    SET @ret = CASE WHEN LEN(@ret) > 0 THEN STUFF(@ret, 1, 1, '')
                    ELSE @ret
               END
	RETURN @ret 
END
GO

--------------2021年1月25日 09:46:11
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		习题试卷标签
-- Create date: 2021年1月25日 09:46:31
-- Description:	
-- =============================================
CREATE FUNCTION FN_QuestionTagsArray(@question_no nvarchar(20), @tags_type nvarchar(20))

RETURNS NVARCHAR(500)
AS
BEGIN
DECLARE @ret NVARCHAR(4000)
    SET @ret = ''
	SELECT @ret = @ret + ',' + RTRIM((APP_TAGS.TAGS_NAME)) FROM APP_TAGS_REF 
	INNER JOIN APP_TAGS ON APP_TAGS_REF.TAGS_NO = APP_TAGS.TAGS_NO AND APP_TAGS.TAGS_TYPE = @tags_type
	WHERE APP_TAGS_REF.REF_NO = @question_no
	GROUP BY  APP_TAGS.TAGS_NAME  
    SET @ret = CASE WHEN LEN(@ret) > 0 THEN STUFF(@ret, 1, 1, '')
                    ELSE @ret
               END
	RETURN @ret 
END
GO


/****** Object:  UserDefinedFunction [dbo].[MB_GetLiveState]    Script Date: 2021/10/9 16:49:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		获取直播状态
-- Create date: 2020年7月28日 15:15:53
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[MB_GetLiveState](@courseNo nvarchar(20))

RETURNS int
AS
BEGIN
DECLARE @start datetime
DECLARE @end datetime
DECLARE @state int
	SET @state = 0;
	SELECT @start = MAX(A.DATE_PLAY), @end=MAX(A.DATE_END) FROM APP_LIVE_COURSE A WHERE A.COURSE_NO = @courseNo
	IF @start > GETDATE()
		BEGIN
		 SET @state = 0
		END
	ELSE IF @start <= GETDATE() AND GETDATE() <= @end
		BEGIN
		  SET @state = 1
		END 
	ELSE
	   BEGIN
		  SET @state = -1
		END 
    RETURN @state 
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		用户是否购买本课程
-- Create date: 2020年7月28日 15:15:53
-- Description:	
-- =============================================
ALTER FUNCTION [dbo].[MB_GetPayCourse](@userCode nvarchar(20),@courseNo nvarchar(20))

RETURNS int
AS
BEGIN
DECLARE @authorization int
	SET @authorization = 0;
	SELECT @authorization = COUNT(A.ORDER_ID) FROM APP_ORDER A WHERE A.ORDER_TYPE = '02' AND A.ORDER_STATE = '02' AND A.USER_CODE = @userCode AND A.REF_NO = @courseNo AND A.TAKE_END >= GETDATE()
	IF @authorization > 0
		BEGIN
		 RETURN 1 
		END
	ELSE
	BEGIN
		SELECT @authorization = COUNT(B.REF_NO) FROM APP_RANK_PERMS B WHERE B.RANK_NO IN(
				SELECT X.RANK_NO FROM APP_ORDER A INNER JOIN APP_RANK_PRODUCT X ON X.PRODUCT_NO = A.REF_NO WHERE A.ORDER_TYPE = '01' AND A.ORDER_STATE = '02' AND A.USER_CODE = @userCode AND A.TAKE_END >= GETDATE()
		) AND B.REF_NO = @courseNo
    END 
    RETURN @authorization 
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		用户是否购买本资料
-- Create date: 2021年10月20日 16:05:16
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[MB_GetPayDownload](@userCode nvarchar(20),@downloadNo nvarchar(20))

RETURNS int
AS
BEGIN
DECLARE @authorization int
	SET @authorization = 0;
	SELECT @authorization = COUNT(A.ORDER_ID) FROM APP_ORDER A WHERE A.ORDER_TYPE = '03' AND A.ORDER_STATE = '02' AND A.USER_CODE = @userCode AND A.REF_NO = @downloadNo AND A.TAKE_END >= GETDATE()
	IF @authorization > 0
		BEGIN
		 RETURN 1 
		END
	ELSE
	BEGIN
		SELECT @authorization = COUNT(B.REF_NO) FROM APP_RANK_PERMS B WHERE B.RANK_NO IN (
				SELECT X.RANK_NO FROM APP_ORDER A INNER JOIN APP_RANK_PRODUCT X ON X.PRODUCT_NO = A.REF_NO WHERE A.ORDER_TYPE = '01' AND A.ORDER_STATE = '02' AND A.USER_CODE = @userCode AND A.TAKE_END >= GETDATE()
		) AND B.REF_NO = @downloadNo
    END 
    RETURN @authorization 
END
GO



