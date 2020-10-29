clc;
close all;

rightSide = [599,595,599,598,598,598,597,597,592,588,583,578,572,572,563,559,550,560,561,558,556,563,553,529,533,527,519,516,519,512,488,497,504,508];
center = [1975,1976,1969,1971,1967,1922,1847,1808,1735,1667,1640,1582,1509,1473,1354,1236,1150,1065,1059,1032,967,921,871,775,721,670,629,565,537,497,442,469,469,474];
leftSide = [228,213,202,221,202,211,218,216,229,1990,1993,1989,1975,1967,1959,1956,1969,1973,1975,1972,1980,1989,2055,2259,2419,2487,2489,2481,2475,2468,2467,2467,2472,976];

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