--�洢����{0]���������{0}����Ϊ�ա�
EXEC sp_addmessage @msgnum = 50001, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_PARM_NULL</MSG_ID><PARMS><PARM>%s</PARM><PARM>%s</PARM></PARMS></ERR_MSG>',  @replace = 'replace'
GO

--û��ά������{0}�ӵ�λ{1}����λ{2}ת���ʡ�
EXEC sp_addmessage @msgnum = 60001, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_UOM_CONVERTION_NOT_FOUND</MSG_ID><PARMS><PARM>%s</PARM><PARM>%s</PARM><PARM>%s</PARM></PARMS></ERR_MSG>',  @replace = 'replace'
GO
--���ϴ���{0}�����ڡ�
EXEC sp_addmessage @msgnum = 60002, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_PT_NO_NOT_EXIST</MSG_ID><PARMS><PARM>%s</PARM></PARMS></ERR_MSG>',  @replace = 'replace'
GO
--������λ{0}�����ڡ�
EXEC sp_addmessage @msgnum = 60003, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_UOM_NOT_EXIST</MSG_ID><PARMS><PARM>%s</PARM></PARMS></ERR_MSG>',  @replace = 'replace'
GO
--ת��������λʱ��������:{0}��
EXEC sp_addmessage @msgnum = 60004, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_CONVERT_UOM</MSG_ID><PARMS><PARM>%s</PARM></PARMS></ERR_MSG>',  @replace = 'replace'
GO


