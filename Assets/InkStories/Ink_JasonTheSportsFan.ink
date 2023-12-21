What's up? #face_player:happy #decay:1
->Choice01
== Choice01 ==
    +[Hey]
        -> Response01_01
    +[Not much bro]
        -> Response01_02
    +[Oh, nothing...]
        -> Response01_03
        
=== Response01_01 ===
What do you want? #standing:11
    -> Choice02
=== Response01_02 ===
Cool... ? #standing:6
    -> Choice02
=== Response01_03 ===
Then, what do you want? ? #standing:1 #face_player:sad
    -> Choice02

== Choice02 ==
#askfriend: #askfriend:
    +[Talk about football]
        -> Choice02_01
    +[Talk about school]
        -> Choice02_02
    +[Tell a joke]
    -> Choice02_04
    
=== Choice02_01 ===
#confidence:10
    +[Did you see the games last night?]#standing:1
        -> Choice02_02_01
    +[Football is so dumb, am I right?] #standing:-5
        -> Choice02_02_02
==== Choice02_02_01 ====
#confidence:10
Yeah, United are so bad, can't believe they haven't sacked that fella yet.
    +[Yeah proper, how many games is that without a win?]  #standing:1
        -> Choice02_02_01_01
    +[To be fair, he doesn't have a lot to work with] 
        -> Choice02_02_02_01
    +[No they are not! United are the best!]
        -> Choice02_02_03_01
===== Choice02_02_01_01 =====
#confidence:10
This is what, their 5th game now? It's not even the fact that they're losing - it's who they're losing to. Like who even are Marino?
    +[They sound like a pizza] 
        -> Choice02_02_01_01_01
    +[They are club founded in 1903 by William Fagen] #standing:-2
        -> Choice02_02_01_01_02
    +[Don't you talk bad on Marino, they're my favourite team] #standing:-1
        -> Choice02_02_01_01_03
    +[Clearly better than United] #standing:2
        -> Choice02_02_01_01_04
====== Choice02_02_01_01_01 ======
#confidence:-5
Yeah I guess? #end:
->END
====== Choice02_02_01_01_02 ======
#confidence:-10
Fella, I didn't ask for a history lesson. #end:
->END
====== Choice02_02_01_01_03 ======
#confidence:-5
Relax mate I was only joking #end:
->END
====== Choice02_02_01_01_04 ======
#confidence:10
Haha yeah proper... I've to go to class now but I'll talk to you later #end:
->END 
===== Choice02_02_02_01 =====
What are you talking about? They literally have some of the best players in the world
->END
===== Choice02_02_03_01 =====
#confidence:-10
Clearly not if they just lost to Marino
    +[They sound like a pizza] 
        -> Choice02_02_01_01_01
    +[I don't care, don't talk bad on United] #standing:-2
        -> Choice02_02_01_01_03
->END
==== Choice02_02_02 ====
#confidence:-25
Says the weirdo wearing a purple vest and sliders #end:
->END
=== Choice02_02 ===
#confidence:2 
    +[This place is a proper kip, init]
        -> Choice02_03
    +[The school's great!]
        -> Choice02_03
        
=== Choice02_03 ===
#confidence:-5
I hate this place, I'd rather be playing football
    +[Talk about football]
        -> Choice02_01
    +[Football is so dumb]
        -> Choice02_02_02
=== Choice02_04 ===
    +[Why'd the chicken cross the road?]
        -> Choice02_04a
    +[Knock-Knock]
        -> Choice02_04b
==== Choice02_04a ====
What?
    +[To Get to the other side]
        -> Response02_04a
    +[Nevermind... it's lame]
        -> Nevermind
==== Choice02_04b ====
Fella what?
    +[Knock Knock]
        -> knockknock
    +[Nevermind... it's lame]
        -> Nevermind
===== Response02_04a ====
#standing:-2
Get away from me #end:
-> END
==knockknock==
Fella what age are you? #end:
->END 
===== Nevermind ====
#confidence:-10 #standing:-2
You're a weirdo #end:
-> END
        
