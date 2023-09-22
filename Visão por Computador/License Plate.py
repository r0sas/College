import sys
import numpy as np
import cv2
import matplotlib.pyplot as plt
import glob
import math
import imutils




def pixelize(img):
    input = img
    height, width = input.shape[:2]
    w, h = (8, 8)
    temp = cv2.resize(input, (w, h), interpolation=cv2.INTER_LINEAR)
    output = cv2.resize(temp, (width, height), interpolation=cv2.INTER_NEAREST)

    return output

images = glob.glob("testdata/*.jpg")
#img = cv2.imread("./testdata/261_jpg.rf.1d8683dae1e67242f70bc8d8a61e59d3.jpg")
#cv2.imshow("Original Image", img)
for i in images:
	img = cv2.imread(i)
	gray_img=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
	[h,w] = gray_img.shape
	gray_img = gray_img[:h-30,:]
	#thresh1,gray_img = cv2.threshold(gray_img,127,255,cv2.THRESH_BINARY_INV)

	rectKern = cv2.getStructuringElement(cv2.MORPH_RECT, (13, 5))
	blackhat = cv2.morphologyEx(gray_img, cv2.MORPH_BLACKHAT, rectKern)
	#canny=cv2.Canny(gray_img,20,200)
	#cv2.imshow("blackhat",blackhat)
	#cv2.imshow("canny",canny)

	squareKern = cv2.getStructuringElement(cv2.MORPH_RECT, (3, 3))
	light = cv2.morphologyEx(gray_img, cv2.MORPH_CLOSE, squareKern)
	light = cv2.threshold(light, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]
	#cv2.imshow("light",light)

	gradX = cv2.Sobel(blackhat, ddepth=cv2.CV_32F,dx=1, dy=0, ksize=-1)
	gradX = np.absolute(gradX)
	(minVal, maxVal) = (np.min(gradX), np.max(gradX))
	gradX = 255 * ((gradX - minVal) / (maxVal - minVal))
	gradX = gradX.astype("uint8")
	#cv2.imshow("Scharr", gradX)


	gradX = cv2.GaussianBlur(gradX, (5, 5), 0)
	gradX = cv2.morphologyEx(gradX, cv2.MORPH_CLOSE, rectKern)
	thresh = cv2.threshold(gradX, 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]
	#cv2.imshow("Grad Tresh", thresh)

	thresh = cv2.erode(thresh, None, iterations=2)
	thresh = cv2.dilate(thresh, None, iterations=2)
	#cv2.imshow("Grad Erode/Dilate", thresh)

	thresh = cv2.bitwise_and(thresh, thresh, mask=light)
	thresh = cv2.dilate(thresh, None, iterations=2)
	thresh = cv2.erode(thresh, None, iterations=1)
	#cv2.imshow("Final", thresh)

	cnts = cv2.findContours(thresh.copy(), cv2.RETR_EXTERNAL,cv2.CHAIN_APPROX_SIMPLE)
	cnts = imutils.grab_contours(cnts)
	cnts = sorted(cnts, key=cv2.contourArea, reverse=True)[:5]

	#(roi, lpCnt) = locate_license_plate(gray_img, cnts)

	minAR = 2
	maxAR = 5
	for c in cnts:
		x,y,w,h=cv2.boundingRect(c)
		perimeter=cv2.arcLength(c,True)
		aprrox=cv2.approxPolyDP(c,0.018*perimeter,True)
		if len(aprrox) >= 4:
			(x, y, w, h) = cv2.boundingRect(c)
			ar = w / float(h)
			# check to see if the aspect ratio is rectangular
			if ar >= minAR and ar <= maxAR:
				screenCnt=aprrox
				#cv2.drawContours(img,[screenCnt],-1,(0,255,0),2)
				#blur = cv2.GaussianBlur(img[screenCnt],(3,3),0)
				img[y:y+h,x:x+w] = pixelize(img[y:y+h,x:x+w])
				cv2.imshow("Plate", img)
				cv2.waitKey(500)
				break;