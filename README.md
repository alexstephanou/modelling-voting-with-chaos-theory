# modelling-voting-with-chaos-theory

# Description of the model
This project was inspired by Self-Organisation -- a subclass of Chaos Theory. Self-organisation is a process where some form of overall order arises from local interactions between parts of an initially disordered system. This is because the system will have certain semi-stable states which differ depending on the initial state of the system. The main components of a simple self-organisation model are the fluctuations of a single item in the system and the overall consensus of the system, ie. there is a competition between micro and macro behaviour. For example, how birds form flocks is a classic example of self-organisation: there is a balance between each bird flying in its own random direction and also seeing other birds and flying with them. The strength of each of these components will determine how well the system self-organises.

This project explores this theory through a simulation (created in Unity using C#) of how a group of people will vote in a political election. A group of people with initially random opinions (either red or blue) have a certain 'strength' of their opinion, programmed in the code. They walk in a random direction until they see a friend, and then move towards that friend to talk to them. Each friend has an impact on the other, and either strengthens or weakens their opinion. If a person's opinion strength reaches sub-zero, their opinion changes to the opposite colour. In this way, the simulation takes into account the component of the model that accounts for the macro behaviour--the system will naturally form a majority which will get stronger and stronger. This means that the outcome of the vote would rely heavily on random fluctuations at the moment that the system tips into either a 'red' state or a 'blue' state. The fluctuations right before the election would have no impact on the result of the vote, and so in a real-life scenario, political campaigning would be most useful at early stages.

However, the user can edit the percentage of people that change their opinion each day due to natural fluctuations. If this number is high enough, the micro behaviour will dominate and there will be no general consensus. This means that the outcome of the vote would rely heavily on small fluctuations right before the election, thus political campaigning would be most useful right before the vote.

# Parameters: 
N: Number of people in the simulation
R: The percentage of N that change their opinion each day. These people are chosen at random each day.
T: The number of days until the election

Initial and final vote count is shown in the simulation, in addition to a countdown until election day and a graph. The graph shows the overall sum of votes (number of blue votes - number of red votes) and plots a point per day (t). 

# A link to the simulation uploaded onto simmer.io is given here: 
https://simmer.io/@alexstephanou/modelling-voting-with-chaos-theory
