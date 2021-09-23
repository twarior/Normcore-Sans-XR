# Normcore-Sans-XR
Normcore Multiplayer in VR Without XR Rig
Normcore works in VR and in the Unity Editor. Both players can move their respective avatars, 
and see the other player's avatar being moved. I think Voice-chat should also work based on
Normcore's own VR Player avatar, which is the base for this project. This avatar contains a
RealtimeView script that I think will handle all the multiplayer based aspects, and we can 
just add our won scripts to it. I added my own crude version of locomotion based on the Left
Analog Stick for Oculus Controllers and WASD movement that changes the transform of the 
player object. 

The next thing that needs to be done is to give each player their own Camera. Ideally this 
would be in 3rd person at first, as I think that would work better for testing in the Unity 
Editor . 
