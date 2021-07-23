# Investigation-and-implementation-of-SLAM-methods

## Abstract
  One of today's most popular research areas is the environmental sensing of autonomous
robots and vehicles. To analyze their environment, we can use light detection and ranging
technology (LIDAR), which will record the spatial position of obstacles in their environment in
the form of point clouds. These measurements can be used to produce relatively accurate geometric
mapping. The popularity of the LIDAR sensor is also due to the fact that its measurements are not
affected by external illumination.
  The aim of my thesis is to implement a mobile robot that is able to map an unknown
environment using a LIDAR sensor and then navigate autonomously in the location it surveys. I
solved this task using the SLAM (Simultaneous Localization and Mapping) algorithm. The data
processing unit of the robot is a Raspberry Pi single board computer. The mapping is done by a
Hokuyo URG type LIDAR sensor, the acceleration and rotation measurement is done by an inertial
measurement unit (IMU). The noise values provided by the IMU are attenuated using an Infinite
Impulse Response (IIR) filter. The resulting robot orientation value and the data extracted from
the LIDAR point cloud were fused using the SLAM algorithm. The measured data and the results
obtained from the algorithms are displayed. I implemented a graphical interface responsible for
robot configuration and monitoring, written in Python and hosted on Raspberry.
  The experiments carried out show that the developed measurement method is well
applicable to the navigation of mobile robots in the presence of obstacles

## Key learnings:
- SLAM
- Hokuyu URG
- RaspbarryPi4
- ROS
- autonom navigation
