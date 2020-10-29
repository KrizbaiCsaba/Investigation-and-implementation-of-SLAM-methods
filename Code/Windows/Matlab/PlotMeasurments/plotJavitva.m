clc;
close all;

rightSide = [351,356,359,355,359,360,358,357,354,349,348,350,346,344,344,346,343,337,337,337,338,340,342,339];
center = [1655,1652,1649,1609,1548,1469,1406,1297,1201,1101,1019,972,916,823,766,699,628,579,553,550,542,552,553,546];
leftSide = [2203,2207,2206,2197,2190,2155,2142,2110,2105,2089,2090,2076,2075,2248,2402,2532,2604,2593,2597,2593,2594,2595,2595,2602];

for t=1:24
    subplot(4,1,1);
    plot(center(t),rightSide(t),'r*');
    axis([0,2000,0,400]);
    xlabel('x')
    ylabel('y');
    title('kozep es bal oldal');
    hold on;
    
    subplot(4,1,2);
    plot(center(t),leftSide(t),'r*');
    axis([0,2000,0,3000]);
    xlabel('x')
    ylabel('y');
    title('kozep es bal oldal');
    hold on;
    
%     subplot(4,1,2);
%     plot(t, rightSide(t),'r*');
%     xlabel('t')
%     ylabel('y');
%     title('job oldal');
%     hold on;
   
    subplot(4,1,3);
    plot(t,center(t),'r*');
    xlabel('t')
    ylabel('x');
    title('kozep');
    hold on;
   
  
    subplot(4,1,4);
    plot(t, leftSide(t),'r*');
    xlabel('t')
    ylabel('y');
    title('bal oldal');
    hold on;
    %pause(1);
end