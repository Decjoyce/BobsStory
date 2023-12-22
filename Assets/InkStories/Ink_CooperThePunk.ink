What's up? #face_player:happy #decay:0.8 #face_npc:sad
->Choice01
== Choice01 ==
    +[Hey there]
        -> Response01_01
    +[I like your t-shirt bro]
        -> Response01_02
        
=== Response01_01 ===
What do you want? #standing:1
    -> Choice02
=== Response01_02 ===
Thank you I guess #standing:2
    -> Choice02


== Choice02 ==
#askfriend: #askfriend:
    +[Talk about football]
        -> Choice02_01
    +[Talk about school]
        -> Choice02_02
    +[Talk about his appearence]
        -> Choice02_03
    +[Tell a joke]
    -> Choice02_04
    
=== Choice02_01 ===
#confidence:-2
    +[What team do yous support?] #standing:-3
        -> Response02_02
    +[Did yous see the games last night?] #standing:-2
        -> Response02_02
    +[Football is so dumb, am I right?] #standing:2
        -> PlayHolder

=== Choice02_02 ===
#confidence:-10
    +[Man I love History, its such an interesting topic.] #standing: -2
        -> Response03_01
    +[This place is a proper kip, init.] #standing:4
        -> Response03_02
    +[School's great!] #standing:-5
        -> Response03_03
        
=== Choice02_03 ===
#confidence:10
    +[Nice shirt what band is that?] #standing:2
        -> Choice03_03_01
    +['Interesting' choice of clothing.] #standing:-4 #confidence: -5
        -> Choice03_03_02
    +[Nevermind] #standing:-1
        -> PlayHolder

=== Choice02_04 ===
    +[Why'd the chicken cross the road?]#standing:-5 
        -> Choice02_04a
    +[Knock-Knock]
        -> Choice02_04a
==== Choice02_04a ====
    +[So it can destroy society] #standing:2
        -> Response02_04a
    +[Nevermind... it's lame] #standing:0
        -> Response02_04b
===== Response02_04a ====
Man what a great joke. Fuck society! #end: #face_npc:happy #face_player:happy
-> Choice02_04a
===== Response02_04b ====
What?
-> Choice02_04a
=== Response02_02 ===
Dude I don't care about football. #end: #face_npc:neutral 
-> DONE
== Response02_01 ==
Ye man its for normies. #end: #face_npc:happy
-> END
=== PlayHolder ===
PlaceHolder
-> END
== Response03_01 ==
Man get a life. #end: #face_player:depressed
-> END
== Response03_02 ==
Fuck ye! #end: #face_player:happy #face_npc:happy
-> END
== Response03_03 ==
OH MY GOD! YOU ARE SUCH A LOSER! #end: #face_player:depressed
-> END
=== Choice03_03_01 ===
#end: #face_npc:happy #face_player:happy
Ye its no biggie, its a small indie band.
-> END
== Choice03_03_03 ==
Ok then? #end: #face_npc:neutral #face_player:sad
->END
=== Choice03_03_02 ===
Says the one with purple shirt and sandels.#end: #face_player:sad
    -> END
