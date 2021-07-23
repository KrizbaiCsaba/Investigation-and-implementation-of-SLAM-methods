#Name: Krizbai Csaba
#Date: 2021. 03. 01

import numpy as np
from scipy import linalg
import math

class Calibration:
    # === Constructor ===
    def __init__(self):
        self.xRef = 0.991521 #xref = cos(6)*1
        self.yRef = -0.279415 #xref = sin(6)*1
        #print("Called Calibraition Constructor!")

    # === Callculate A invere matrix a b ===
    # parameters: magneto X, Y, Z value
    # return: Ainv, b matrix
    def calculateAInv(self, magX, magY, magZ):
        Q, n, d = self.fitEllipsoid(magX,magY, magZ)
        Qinv = np.linalg.inv(Q)
        b = - np.dot(Qinv, n)
        isNotNegative = np.dot(n.T, np.dot(Qinv, n)) - d
        if isNotNegative > 0:
            Ainv = np.real( 1 / np.sqrt(isNotNegative) * linalg.sqrtm(Q))
            return  Ainv, b
        else:
            return np.array([[-9999 , -9999], [-9999, -9999]]) , -9999

    # === Callculate Theta value ===
    # parameters:  magneto X, magneto Y, magneto Z, A inverse, b
    # return: theta
    def calculateTheta(self, magX, magY, magZ, Ainv, b):
        calibratedX = np.zeros(magX.shape)  # zeros(x) -> return array with dim x
        calibratedY = np.zeros(magY.shape)  # x.shape -> Return the shape of an array x

        h = np.array([[magX[0], magY[0], magZ[0]]]).T
        hHat = np.matmul(Ainv, h - b)
        calibratedX = hHat[0]
        calibratedY = hHat[1]

        return calibratedX, calibratedY


    # parameters: magneto X, Y, Z value
    # return:Q, n, d
    def fitEllipsoid(self, magX, magY, magZ):
        a1 = magX ** 2
        a2 = magY ** 2
        a3 = magZ ** 2
        a4 = 2 * np.multiply(magY, magZ)
        a5 = 2 * np.multiply(magX, magZ)
        a6 = 2 * np.multiply(magX, magY)
        a7 = 2 * magX
        a8 = 2 * magY
        a9 = 2 * magZ
        a10 = np.ones(len(magX)).T
        D = np.array([a1, a2, a3, a4, a5, a6, a7, a8, a9, a10])

        # Eqn 7, k = 4
        C1 = np.array([[-1, 1, 1, 0, 0, 0],
                       [1, -1, 1, 0, 0, 0],
                       [1, 1, -1, 0, 0, 0],
                       [0, 0, 0, -4, 0, 0],
                       [0, 0, 0, 0, -4, 0],
                       [0, 0, 0, 0, 0, -4]])

        # Eqn 11
        S = np.matmul(D, D.T)
        S11 = S[:6, :6]
        S12 = S[:6, 6:]
        S21 = S[6:, :6]
        S22 = S[6:, 6:]

        # Eqn 15, find eigenvalue and vector
        # Since S is symmetric, S12.T = S21
        tmp = np.matmul(np.linalg.inv(C1), S11 - np.matmul(S12, np.matmul(np.linalg.inv(S22), S21)))
        eigenValue, eigenVector = np.linalg.eig(tmp)
        u1 = eigenVector[:, np.argmax(eigenValue)]

        # Eqn 13 solution
        u2 = np.matmul(-np.matmul(np.linalg.inv(S22), S21), u1)

        # Total solution
        u = np.concatenate([u1, u2]).T

        Q = np.array([[u[0], u[5], u[4]],
                      [u[5], u[1], u[3]],
                      [u[4], u[3], u[2]]])

        n = np.array([[u[6]],
                      [u[7]],
                      [u[8]]])

        d = u[9]

        return Q, n, d

