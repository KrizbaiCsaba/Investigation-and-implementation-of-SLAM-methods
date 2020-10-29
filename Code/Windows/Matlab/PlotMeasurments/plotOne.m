clc;
close all;

step60 = [523,599,609,570,555,545,539,531,529,525,527,516,517,515,525,538,566,556,545,584,599,399,300,190];
step33 = [1402,2736,2711,1462,2653,2661,2545,2542,2498,2403,2336,2250,2171,2081,816,745,654,511,414,315,1393,257,173,124];
step0 =  [89,3181,3189,3190,3200,3219,3228,3250,3263,3261,3268,419,439,379,410,404,387,428,3362,3392,3411,3414,215,213];


figure(1)

for t=1:24
    subplot(3,1,1);
   plot(step33(t),step60(t),'r*');
   xlabel('x')
    ylabel('y');
   hold on;
   
    subplot(3,1,2);
   plot(t,step33(t),'r*');
   xlabel('t')
    ylabel('x');
  hold on;
   
  
    subplot(3,1,3);
   plot(t, step60(t),'r*');
   xlabel('t')
    ylabel('y');
   hold on;
   %pause(1);
end
%plot(step0,step60,'r*');


% 
% subplot(2,1,2);
% plot(step0,step33);
% xlabel('step0')
% ylabel('step33');


figure(2);
subplot(3,1,1);
t=1:24;
plot(t,step0);
title('STEP0 - baloldal');

subplot(3,1,2);
t=1:24;
plot(t,step33);
title('STEP33 - kozepe');

subplot(3,1,3);
t=1:24;
plot(t,step60);
title('STEP66 - job');
