--����{0}���������{0}����Ϊ�ա�
EXEC sp_addmessage @msgnum = 50001, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_PARM_NULL</MSG_ID><PARMS><PARM>%s</PARM><PARM>%s</PARM></PARMS></ERR_MSG>',  @replace = 'replace'
GO

--��ȡ˳��Ŵ洢���̵�BatchSize��������С�ڵ���0��
EXEC sp_addmessage @msgnum = 50002, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_BATCH_SIZE_LE_ZERO</MSG_ID></ERR_MSG>',  @replace = 'replace'
GO

--{0}ʱ��������:{1}��������{2}��
EXEC sp_addmessage @msgnum = 50003, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_EXEC_SP</MSG_ID><PARMS><PARM>%s</PARM><PARM>%s</PARM><PARM>%d</PARM></PARMS></ERR_MSG>',  @replace = 'replace'
GO

--����ִ��ʱ��������:{1}��������{2}��
EXEC sp_addmessage @msgnum = 50004, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_INNER_ERROR</MSG_ID><PARMS><PARM>%s</PARM><PARM>%d</PARM></PARMS></ERR_MSG>',  @replace = 'replace'
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

--�۸񵥱�ʶ{0}�����ڡ�
EXEC sp_addmessage @msgnum = 60004, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_PUR_PL_ID_NOT_EXIST</MSG_ID><PARMS><PARM>%d</PARM></PARMS></ERR_MSG>',  @replace = 'replace'
GO

--�����Ѿ������£������ԡ�
EXEC sp_addmessage @msgnum = 60005, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_DATA_CONCURRENCY</MSG_ID>',  @replace = 'replace'
GO

--�ɹ��۸񵥱�ʶ{0}�����ڡ�
EXEC sp_addmessage @msgnum = 60006, @severity = 16, @msgtext = N'<ERR_MSG><MSG_ID>ERRORS_PUR_PL_ID_NOT_FOUND</MSG_ID><PARMS><PARM>%d</PARM></PARMS></ERR_MSG>',  @replace = 'replace'
GO



