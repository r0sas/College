# importing libraries
import numpy as np
import cv2




def pixelize(img):
    input = img
    height, width = input.shape[:2]
    w, h = (3, 2)
    temp = cv2.resize(input, (w, h), interpolation=cv2.INTER_LINEAR)
    output = cv2.resize(temp, (width, height), interpolation=cv2.INTER_NEAREST)

    return output



  
kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (2, 2));
  
# creating object
fgbg = cv2.createBackgroundSubtractorMOG2();
  
# capture frames from a camera 
cap = cv2.VideoCapture('Oxford Town Centre/input_video_s2_l1_01.mp4')

output_filename = 'background_subtraction.mp4'
output_frames_per_second = 20.0
file_size = (768,576)
scale_ratio = 1

fourcc = cv2.VideoWriter_fourcc(*'mp4v')
result = cv2.VideoWriter(output_filename,  
                        fourcc, 
                        output_frames_per_second, 
                        file_size) 

i = 1
while(1):
    # read frames
    ret, img = cap.read();
    # apply mask for background subtraction
    fgmask = fgbg.apply(img);
      
    fgmask = cv2.morphologyEx(fgmask, cv2.MORPH_OPEN, kernel);
    fgmask = cv2.medianBlur(fgmask, 5)

    thresh=cv2.erode(fgmask, kernel, iterations=2)

    fgmask=thresh
    cnts = cv2.findContours(thresh.copy(), cv2.RETR_EXTERNAL,cv2.CHAIN_APPROX_SIMPLE)
    cnts = cnts[0] if len(cnts) == 2 else cnts[1]

    for c in cnts:
        cv2.contourArea(c)
        if cv2.contourArea(c)>80:
            x,y,w,h=cv2.boundingRect(c)
            cv2.rectangle(fgmask, (x + int(w*0.15), y), (x + w - int(w*0.15), y + h - int(h*0.8)), (255,0,0), 4)
            #cv2.rectangle(fgmask, (x, y), (x + w, y + h), (255,0,0), 4)
            img[y:y + h - int(h*0.8) - 1,(x + int(w*0.15)):(x + w - int(w*0.15))] = cv2.blur(img[y:y + h - int(h*0.8) - 1,(x + int(w*0.15)):(x + w - int(w*0.15))],(10,10))
            #cv2.rectangle(fgmask, (x + int(w*0.3), y), (x + w - int(w*0.3), y + h - int(h*0.8)), (255,0,0), 4)
    #cv2.imwrite('frames\ '+ str(i) +'.jpg',img)
    result.write(img)
      
    # after removing noise
    cv2.imshow('GMG', fgmask);
    cv2.imshow('Final', img);
    cv2.imwrite("face_blur_image.jpg", img)
    cv2.waitKey(100) & 0xff;

cap.release();
out.release()
cv2.destroyAllWindows();