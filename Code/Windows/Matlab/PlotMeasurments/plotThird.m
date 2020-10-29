clc;
close all;

rightSide = [481,483,479,487,482,490,489,490,488,489,489,496,489,493,488,493,486,485,477,472,469,461,467,462,452,463,436,425,425,424,414,414,422,424];
center = [481,483,479,487,482,490,489,490,488,489,489,496,489,493,488,493,486,485,477,472,469,461,467,462,452,463,436,425,425,424,414,414,422,424];
leftSide = [169,179,175,170,174,183,2252,2249,2248,2258,2252,2256,2261,2270,2275,2284,2289,2295,2285,2290,2291,2296,2307,2311,2315,2331,2335,2297,2298,2292,2284,2287,2297,2290];

for t=1:34
    subplot(4,1,1);
    plot(center(t),leftSide(t),'r*');
    xlabel('x')
    ylabel('y');
    title('kozep es bal oldal');
    hold on;
    
    subplot(4,1,2);
    plot(t, rightSide(t),'r*');
    xlabel('t')
    ylabel('y');
    title('job oldal');
    hold on;
   
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