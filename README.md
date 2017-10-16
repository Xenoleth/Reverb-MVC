# Reverb-MVC
##### (aka Rock-Metal-MVC)

*A music site that offers information about songs. Add new songs and then listen to them. (gasp) *

### 1. Administrative functionality:

* Edit songs

"~/song/editsong?songId=GUID"

* Add songs, albums, genres and artists

"~/create/creationchoice"

"~/create/createsong"

"~/create/createartist"

"~/create/createalbum"

"~/create/creategenre"



### 2. Mundane users:
* Favorite songs

Button on song cards in "/song/library" or "/song/details?songId=GUID"

* View song details and play videos

"~/song/details?songId=GUID"


### 3. Anonomys users:

* Search for songs in the music library

Access only to "~/song/library" where you can searchg for songs by name, albumm, artist and order by each of them.
