%ReadFromSerail
clc;
clear all;
close all;


delete(instrfindall);
lidar=serial('COM9','baudrate',115200);
set(lidar,'Timeout',1);
set(lidar,'InputBufferSize',40000);
set(lidar,'Terminator','CR');
fopen(lidar);
pause(0.1);
fprintf(lidar,'SCIP2.0');
pause(0.1);
fscanf(lidar);

fprintf(lidar,'VV');
pause(1);
fscanf(lidar)

fprintf(lidar,'BM');
pause(1);
fscanf(lidar)

fprintf("MD kuldes");
fprintf(lidar,'MD');
pause(1);
fprintf("MD fogadas");
fscanf(lidar)

fprintf(lidar,'MD');
pause(1);
bytes_expect = 12; % Number of bytes expected
query_resp = fread(lidar, bytes_expect, 'char')'; % Receive response from controller


s = LidarScan(lidar);


fprintf(lidar,'QT');
fclose(lidar);
close all;