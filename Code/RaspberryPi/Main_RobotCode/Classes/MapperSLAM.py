# Name: Krizbai Csaba
# Date: 2021. 06. 10

#=== Imports ===
import matplotlib.pyplot as plt
import matplotlib.lines as mlines
import matplotlib.cm as colormap
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
import numpy as np

#=== Const ===
FIG_SIZE = 5.5

#=== DrawMAP Class ===
class DrawMAP():
    def __init__(self, rootUI, pixelSize, meterSize, Title = "Mapper SLAM"):
        self.figure = plt.Figure(figsize = (FIG_SIZE, FIG_SIZE), facecolor = '#12232E') #width 550, heigth = 550
        self.canvas = FigureCanvasTkAgg(self.figure, master=rootUI)
        self.canvas.get_tk_widget().place(x =10, y =10)
        self.mapSize = pixelSize #size in pixel
        
        self.ax = self.figure.gca() #getCurentAxes
        
        self.ax.set_xlabel('X (m)')
        self.ax.set_ylabel('Y (m)')
        self.ax.set_title(Title)
        self.ax.grid(True)
        self.prevpos = None
        self.prevRobotPos = None
        
   
        
        
        
    # === Update ===
    # param: robot position = [x, y] , robot angle = theta, MAP in byte array = mapbytes
    def update(self,root, x, y, theta, mapbytes):
        #print("MapperSLAM: ",mapbytes)
        mapimg = np.reshape(np.frombuffer(mapbytes, dtype=np.uint8), (self.mapSize, self.mapSize))
        root.ax.imshow(mapimg, cmap=colormap.gray)
        root.setRobotPosition(x, y, theta)
        plt.pause(.001)
        plt.draw()
        #self.chart_type.pause(.001)
        #self.figure.canvas.draw_idle()
        #self.canvas.draw()
        
    # === setRobotPosition ===
    def setRobotPosition(self, x, y, theta):
        #delete last position
        if self.prevRobotPos != None:
            self.prevRobotPos.remove()
        theta_rad = np.radians(theta)
        dx = np.cos(theta_rad)
        dy = np.sin(theta_rad)
        self.prevRobotPos = self.ax.arrow(x , y, dx, dy, width = 2, color = 'r') #draw roboot position
        currpos = [x, y]
        if self.prevpos != None:
            self.ax.add_line(mlines.Line2D((self.prevpos[0],currpos[0]), (self.prevpos[1],currpos[1]), color = 'g'))
        self.prevpos = currpos #save last position
        
        