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
    +[Talk about the weather]
        -> Choice02_03
    +[Tell a joke]
    -> Choice02_04
    
=== Choice02_01 ===
#confidence:5
    +[What team do yous support?]
        -> Choice03_04
    +[Did yous see the games last night?]
        -> Response02_02
    +[Football is so dumb, am I right?]
        -> Choice03_04

=== Choice02_02 ===
#confidence:2 
    +[Geography's poxy, init]
        -> Choice03_04
    +[This place is a proper kip, init]
        -> Choice03_04
    +[The school's great!]
        -> Choice03_04
        
=== Choice02_03 ===
#confidence:-50 
    +[Lovely weather we're having right?]
        -> Choice03_04
    +[The weather is so bad]
        -> Choice03_04
    +[Nevermind]
        -> Choice03_04

=== Choice02_04 ===
    +[Why'd the chicken cross the road?]
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
=== Choice03_04 ===
Then what do you want?
    -> END
