What's up? #face_player:happy #decay:1
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
#confidence:5
    +[What team do yous support?]
        -> PlayHolder
    +[Did yous see the games last night?]
        -> Response02_02
    +[Football is so dumb, am I right?]
        -> PlayHolder

=== Choice02_02 ===
#confidence:2 
    +[Geography's poxy, init]
        -> PlayHolder
    +[This place is a proper kip, init]
        -> PlayHolder
    +[The school's great!]
        -> PlayHolder
        
=== Choice02_03 ===
#confidence:10
    +[Nice shirt what band is that?] #standing:2
        -> Choice03_03_01
    +['Interesting' choice of clothing.] #standing:-3 #confidence: -5
        -> Choice03_03_02
    +[Nevermind]
        -> PlayHolder

=== Choice02_04 ===
    +[Why'd the chicken cross the road?]#standing:-5 
        -> Choice02_04a
    +[Knock-Knock]
        -> Choice02_04a
==== Choice02_04a ====
    +[To Get to the other side]
        -> Response02_04a
    +[Nevermind... it's lame]
        -> Response02_04b
===== Response02_04a ====
What?
-> Choice02_04a
===== Response02_04b ====
What?
-> Choice02_04a
=== Response02_02 ===
Yeah, United are so bad, can't believe they haven't sacked that fella yet.
-> DONE
=== PlayHolder ===
PlaceHolder.
-> END
=== Choice03_03_01 ===
Ye its no biggie, its a small indie band.#end:
-> END
=== Choice03_03_02 ===
Says the one with purple shirt and sandels.#end: 
    -> END
