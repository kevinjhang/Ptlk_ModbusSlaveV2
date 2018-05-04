@echo off

.\protoc.exe --proto_path=..\protos --csharp_out=..\Model devices.proto

pause