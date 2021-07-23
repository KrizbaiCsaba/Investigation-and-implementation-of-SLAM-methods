import matplotlib.pyplot as plt
import numpy as np



# use ggplot style for more sophisticated visuals
plt.style.use('ggplot')

def live_plotter(x_vec,y1_data, y2_data,y3_data, line1, line2 , line3,identifier = '', pause_time=0.05):
    if line1 == []:
        # this is the call to matplotlib that allows dynamic plotting
        plt.ion()
        fig = plt.figure(figsize=(13,6))
        plt.title('Title: {}'.format(identifier))
        
        # === SUBPLOT 1 ===
        ax1 = fig.add_subplot(111)

        line1, = ax1.plot(x_vec,y1_data,'-o',alpha=0.8)
        line2, = ax1.plot(x_vec,y2_data,'-o',alpha=0.8)
        line3, = ax1.plot(x_vec,y3_data,'-o',alpha=0.8)
        
        plt.ylabel('angle')
        plt.xlabel('time')

        #update plot label/title
        plt.show()
       
        
        
     
    
    # after the figure, axis, and line are created, we only need to update the y-data
    line1.set_ydata(y1_data)
    line2.set_ydata(y2_data)
    line3.set_ydata(y3_data)
    # adjust limits if new data goes beyond bounds
    ajustLimits(line1, y1_data)
    ajustLimits(line2, y2_data)
    ajustLimits(line3, y3_data)
    # this pauses the data so the figure/axis can catch up - the amount of pause can be altered above
    plt.pause(pause_time)
    
    # return line so we can update it again in the next iteration
    return line1, line2, line3

def ajustLimits(line, data):
    if np.min(data)<=line.axes.get_ylim()[0] or np.max(data)>=line.axes.get_ylim()[1]:
        plt.ylim([np.min(data)-np.std(data),np.max(data)+np.std(data)])