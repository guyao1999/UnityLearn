rem �л���.protoЭ�����ڵ�Ŀ¼  
cd D:\chromeDownload\protoc-gen-lua\luascript  
rem ����ǰ�ļ����е�����Э���ļ�ת��Ϊlua�ļ�  
for %%i in (*.proto) do (    
echo %%i  
"D:\chromeDownload\protoc-gen-lua\protoc.exe" --plugin=protoc-gen-lua="D:\chromeDownload\protoc-gen-lua\plugin\protoc-gen-lua.bat" --lua_out=. %%i  
  
)  
echo end  
pause