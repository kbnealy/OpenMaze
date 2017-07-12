# MorrisMaze
This is a simulation of the water maze experiment written in Unity C#.
The way that the system is designed is for maximum configuration

##### Python files
Python files go starting in relative path to Assets/InputFiles.
The python script expects input as follows:

Given an integer that represents the the type of trial, the program has to output
exactly 1 x, y pair for the pickup object.

See [this file](Assets/InputFiles/Example.py)
for an example.


##### Configuration Detail
Note the initial configuration file is input.json located in
[here](Assets/InputFiles)

Experiment.csv will be the configuration file for the experiment.
The way it will work is as follows, in each row:

<Scene Number (0, 1)>, <Time in Scene>, Target Type will represent a specific type based on the types in input.json array indexed starting at 0, NumWalls, <Time until reset>

i.e. a row that looks like

<p style="text-align: center;">0, 10, 1, 4, 3 <p>

means:
We will be in scene 0. There is 10 seconds to find the target which is type 1 (based on order inside input.json), With 4 walls and 3 seconds for transition.

It will keep proceeding as follows until there are no more rows. In order to run the experiment, the [N] key must be pressed with the [K, L] entering regular developer mode. Once the experiment begins, it can be ended by pressing the [0] key. (This can only be done in developer mode). Each row will generate its own output.csv file.


##### List of Available Commands (Developer Mode Only):
1. [1] to INCREASE number of walls by offset
2. [2] to DECREASE number of walls by offset
3. [3] to get a random wall
4. [space] to commit your changes
5. [WASD and arrow keys] will work to control character
6. [G] to take a screen shot of the current game system
7. [H] to run through screen shots of the entire system
8. [F] to save the current file
9. [K and L] will switch between keys