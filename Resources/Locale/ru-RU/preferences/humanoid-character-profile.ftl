### UI

# Displayed in the Character prefs window
humanoid-character-profile-summary =
    Это { $name }. { $gender ->
        [male] Ему
        [female] Ей
       *[other] Этому
    } { $age } { $age ->
	    [one] год
	    [few] года
       *[other] лет
    }.
