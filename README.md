# VIRTUAL REALITY TRUNK MUSCLE TRAINING SYSTEM
To act as a patient interface to the training application, a smartphone app will be required to start virtual reality program. 
This has the added benefit of being able to integrate into a wearable headset with the smartphone as a VR screen, such as google cardboard
or similar VR headset device. The phone can track patient head movements separately from trunk movements. The app will be programmed for
Android devices, using Unity 3D and C# in compatibility mode with the android Software Development Kit (SDK). After a brief loading screen
, the patient will be prompted with selection menu options such as Calibration, Play, Live Data, Quit and Manual Override. 
These options will be selected using the timed gaze input modality, so that no hand movements or external devices are required to 
interact with the VR space. Auditory and visual feedback will be provided to ensure a smooth and accessible VR experience.

# Motivation

Currently, there is a need for intensive research efforts in the fields of geriatrics, exercise science and physiotherapy to address rising age-related and cost-intensive health care problems. One of the biggest problems in the field of geriatrics is the high prevalence of falls due to aging causing functional, neural and muscular deterioration. Current mitigation techniques to offset this effect traditionally include balance/lower extremity resistance training. However, the effects of this type of training poorly translates to real life which leads to insignificant improvements in balance and daily activities. This project aims to address this issue by providing an interactive training experience that includes live biofeedback to monitor trunk muscle activity. The proposed design will make use of multiple electromyograph (EMG) sensors embedded into a wearable belt to monitor trunk muscle activity during training. The set-up of the training will incorporate an interactive virtual reality environment which will have built-in training applications that the user can follow. The training also makes use of a limited Aerotrim structure that can be triggered to move in two dimensions, Pitch and Roll. 

# Overiew

### Main Menu
Upon opening the application, the user will first be prompted with a menu screen that displays 4 different options. The Calibration option will return both the pitch and roll of the Spaceball to its center position. The Play option will send the player to another menu where they can select a game of their choosing. The Live Data option will allow the user to see real time biofeedback via EMG sensors in the trunk muscles of their choosing. The Quit option will simply leave and close the application.

![mainmenu](https://user-images.githubusercontent.com/47070972/56940448-8a784d00-6adc-11e9-99b0-547d609c9978.png)

Associated files: ![Buttons](Assets/ButtonManager.cs) ![Timed Gaze Input](Assets/Scripts) ![Menu Screen](Assets/Scenes)

### Calibration

Once the Calibration option in the main menu is selected, a C# script will be triggered to initiate a server-client connection between the application and the microcontroller on the Spaceball circuit. Starting from the server side, the microcontroller is set up to receive a message from the application which will correspond to a 3-digit number code. Clicking the calibration button will send a data message that starts with the character ‘0’ to the microcontroller. The microcontrollers code 
([Spaceball Code](https://github.com/GxRay/VR_Simulator-Spaceball)) is set up such that any message that starts with the ‘0’ character will initiate a calibrate function. This function will cause the Spaceball the move such that the user sitting inside is centered, the calibrate function was determined via testing in section 9.1. For troubleshooting/testing purposes, a Manual Override option (seen below)  button was added to the main menu to manually control the Spaceball. Pressing this button will lead to another screen where the user can manually move the Spaceball in both Pitch and Roll motions incrementally. 
![cmenu](https://user-images.githubusercontent.com/47070972/56941752-9700a380-6ae4-11e9-9414-21f9030fa13c.png)

Associated files: ![WIFI Communication Between Spaceball and Unity](Assets/SpaceBall_Sender.cs)
### Gameplay

Once the training simulation starts, objects start getting thrown toward the user. These objects come in the form of weapons that the user must dodge, and gems that the user will have to collect. The purpose of implementing this system was to motivate the user to train their muscles through gamification. In order to dodge/collect the objects, the user will have to move their torso away from the object. This movement is tracked by the accelerometer attached to the Wearable Acquisition Belt. As the user tilts away from the oncoming objects, they will use their trunk muscles as it is primarily responsible for tilting movements. The EMG activity of the muscles will be recorded via the Wearable Acquisition Belt and be displayed on the HUD throughout the training simulation, which allows for the user to be aware of how much their trunk muscles are being activated.  The training simulation will also trigger Spaceball movements, the purpose of this is to put users in positions where they must use more of their trunk muscles  in order to keep it stable.  As the training simulation progresses, the game will get more difficult through the more frequent movement of the Spaceball and faster object spawning.

Player view in game:
![gpic](https://user-images.githubusercontent.com/47070972/56942396-82260f00-6ae8-11e9-807f-9e6f8d7d04ff.png)
Spaceball moving in correspendence to in-game commands:
![dfsdv](https://user-images.githubusercontent.com/47070972/56942423-b26dad80-6ae8-11e9-8fe5-ae6d9ae58ba6.PNG)

Associated files: ![Getting Biofeedback from EMG Belt](Assets/Data_Aquisition.cs) 
![Accelerometer Input to Tilt Player](Assets/AccelTilt.cs)
![Player Collision](Assets/Player_Collision.cs)
![Weapon & Gem Spawner](Assets/WaveSpawner.cs)
![Player Score Tracker](Assets/Player_Statistics.cs) 

### Live Data

The Live data menu selection allows for users to see selective muscle groups EMG activity in real time.  The trunk muscles are split into 3 muscle groups; which consists of the Rectus Abdominus muscles (left and right), External Obliques (left and right) and the Erector Spinae. In the menu, the user can select which muscle group they would like to view (seen on the left below), after selection the graphs will be enabled which will display the corresponding muscle activity (seen on the left below).  The user can then try activating their trunk muscles through flexing or performing tilting movements and see each muscles groups contribution to the movement/flexion.

![sdsd](https://user-images.githubusercontent.com/47070972/56943327-fbbffc00-6aec-11e9-9d89-be34fc624b86.png)


Associated files: ![Graphing EMG Data](Assets/Chart and Graph/Tutorials/Stream Graph/StreamingGraph.cs)
