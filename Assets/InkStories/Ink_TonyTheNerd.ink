What's up? #face_player:neutral #decay:1
->Choice01
== Choice01 ==
    +[Hey]
        -> Response01_01
    +[Nothing much...]
        -> Response01_02
        
=== Response01_01 ===
What do you want? #standing:3
    -> Choice02
=== Response01_02 ===
Cool...? #standing:1
    -> Choice02

== Choice02 ==
#askfriend: #askfriend:
    +[Talk about football]
        -> Choice02_01
    +[Talk about school]
        -> Choice02_02
    +[Talk about starwars]
        -> Choice02_03
    +[Tell a joke]
    -> Choice02_04
    
=== Choice02_01 ===
#confidence:5
    +[What team do yous support?]
        -> Response03_04
    +[Did yous see the games last night?]
        -> Response02_02
    +[Football is so dumb, am I right?]
        -> Response03_04_01

=== Choice02_02 ===
#confidence:5 
    +[Geography's poxy, init]
        -> Response03_04_02
    +[This place is a proper kip, init]
        -> Response03_04_03
    +[The school's great!]
        -> Response03_04_04
        
=== Choice02_03 ===
#confidence:7 
    +[Do you like the starwars game?]
        -> Response04
    +[We should have a jedi fight]
        -> Response03_04_05
    +[Starwars is so bad, right?]
        -> Response03_04_06

=== Choice02_04 ===
#confidence:4 
    +[Why'd the chicken cross the road?]
        -> Choice02_04a
    +[Knock-Knock]
        -> Choice02_04a
==== Choice02_04a ====
#confidence:3 
    +[To Get to the other side]
        -> Response02_04a
    +[Nevermind... it's lame]
        -> Response02_04b
===== Response02_04a ====
That's it?? #end: #standing:-5 #face_player:depressed #decay:5
-> END

===== Response02_04b ====
What?? #end: #standing:-6  #face_player:depressed #decay:5
-> END

=== Response02_02 ===
Yeah, that DnD game was crazy!! #end: #standing:2 #face_player:happy  #decay:5
-> END

=== Response03_04 ===
Huh? Oh Yeah i support gryffindor? #end: #standing:2 #face_player:happy  #decay:5
-> END

=== Response03_04_01 ===    
Yeah, football is super dumb... #end: #standing:1 #face_player:neutral  #decay:5
-> END

=== Response03_04_02 ===
Yeah, im a nerd and i dont even like it! #end: #standing:1 #face_player:neutral #decay:5
-> END

=== Response03_04_03 ===
Roger, there's not enough games! #end: #standing:1 #face_player:neutral  #decay:5
-> END

=== Response03_04_04 ===
Ehh, it's okay i guess... #end: #standing:-1 #face_player:neutral  #decay:5
-> END

=== Response03_04_05 ===
Im down, let's start swinging! #end: #standing:3 #face_player:happy  #decay:5
-> END

=== Response03_04_06 ===
WHAT?! what the hell are you saying! #end: #standing:-5 #face_player:depressed  #decay:5
-> END

=== Response04 ===
Huh, of course i like them! #confidence:5 #face_player:happy

    +[Jedi Survivor!]
        -> Response05
    +[Lego Starwars!]
        -> Response05_01
    +[All of them obviously?]
        -> Response05_02

===Response05===
eh, it's alright... #end: #standing:-1 #face_player:neutral  #decay:5
-> END

===Response05_01===
My two favourite things! #end: #standing:4 #face_player:happy  #decay:5
-> END

===Response05_02===
They all can't be great? #end: #standing:-3  #face_player:sad  #decay:5
-> END

