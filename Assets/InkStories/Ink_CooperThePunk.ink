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
#confidence:-2
    +[What team do yous support?] #standing:-3
        -> PlayHolder
    +[Did yous see the games last night?] #standing: -2
        -> Response02_02
    +[Football is so dumb, am I right?] #standing:2
        -> PlayHolder

=== Choice02_02 ===
#confidence:-10
    +[Geography's poxy, init] #standing: -2
        -> PlayHolder
    +[This place is a proper kip, init] #standing:4
        -> PlayHolder
    +[School's great!] #standing:-5
        -> PlayHolder
        
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
    +[So it can destroy society] #standing: 2
        -> Response02_04a
    +[Nevermind... it's lame] #standing: 0
        -> Response02_04b
===== Response02_04a ====
What?
-> Choice02_04a
===== Response02_04b ====
What?
-> Choice02_04a
=== Response02_02 ===
Dude I don't care about football. #end
-> DONE
=== PlayHolder ===
PlaceHolder
-> END
=== Choice03_03_01 ===
Ye its no biggie, its a small indie band.#end:
-> END
=== Choice03_03_02 ===
Says the one with purple shirt and sandels.#end: 
    -> END
