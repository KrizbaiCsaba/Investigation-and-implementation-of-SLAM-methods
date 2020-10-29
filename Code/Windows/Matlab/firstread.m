clc;clear all;close all;

start_point = 44;
end_point = 725;
cluster = 1;


URG=serial('COM9','baudrate',115200);
set(URG,'Timeout',1);
set(URG,'InputBufferSize',50000);
set(URG,'Terminator','LF');

if ~isempty(instrfind)
     fclose(instrfind);
      delete(instrfind);
end
fopen(URG);
pause(0.1);

fprintf(URG,'BM');
pause(0.1);

while(URG.BytesAvailable~=0)
    fgetl(URG);
end


%fprintf(URG,scan_cmd);

while(URG.BytesAvailable==0)
    pause(0.001);
end

fgetl(URG); % echo
fgetl(URG); % status

timestamp=decodeSCIP_timestamp(fgetl(URG)); % 24bit timer, 1ms resolution

data=[];
while(URG.BytesAvailable>2)
    data=[data;range_convert(fgetl(URG))];
end

fgetl(URG); % LFLF

pause(0.1);
fprintf(URG,'QT');
pause(0.1);

while(URG.BytesAvailable~=0)
    fgetl(URG);
end

fclose(URG);

angles=(((start_point-384):cluster:(end_point-384))*2*pi/1024)';

data_xy(:,1)=-(data/1000).*sin(angles);
data_xy(:,2)=(data/1000).*cos(angles);

scatter(data_xy(:,1),data_xy(:,2),'r.');
grid on
axis equal;
axis([-4.25 4.25 -4.25 4.25])
shg