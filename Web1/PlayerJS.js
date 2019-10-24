//取得document object
var audio = document.getElementById("audio");
var ControlPanel = document.getElementById("ControlPanel");
var music = document.getElementById("music");
var song = document.getElementById("song");
var duration = document.getElementById("duration");
var info = document.getElementById("info");
var info2 = document.getElementById("info2");
var vol = document.getElementById("vol");
var volValue = document.getElementById("volValue");
var stop = document.getElementById("stop");
var progress = document.getElementById("progress");
//var settime = document.getElementById("settime");
var Sbook = document.getElementById("Sbook");
var Tbook = document.getElementById("Tbook");
var book = document.getElementById("book");
var btnUpdateMusic = document.getElementById("btnUpdateMusic");

//加入事件監聽器
ControlPanel.addEventListener("click", objEvent);
music.addEventListener("change", function () { changeMusic(music.selectedIndex); });
vol.addEventListener(browserTest(), function () { volumeChange(1); });
progress.addEventListener(browserTest(), setTimeBar);
Sbook.addEventListener("dragstart", drag);
Tbook.addEventListener("dragover", allowDrop);
Tbook.addEventListener("drop", function () { drop(event, this); });

Tbook.addEventListener("dragstart", drag);
Sbook.addEventListener("dragover", allowDrop);
Sbook.addEventListener("drop", function () { drop(event, this); });

btnUpdateMusic.addEventListener("click", updateMusic);
//一開始抓預設的歌
defaultSong();

//瀏覽器偵測
function browserTest() {
    if (navigator.userAgent.search("Chrome") != -1)
        return "input";
    else if (navigator.userAgent.search("Firefox") != -1)
        return "input";
    else if (navigator.userAgent.search("Opera") != -1)
        return "input";
    else
        return "change";
    //console.log(navigator.userAgent);
}

//各項功能函數
//判斷要執行哪一個功能
function objEvent(evt) {
    console.log(evt.target);
    obj = evt.target;
    //id = evt.target.id;
    switch (obj.id) {
        case "play":
            playMusic(obj);
            break;
        case "pause":
            pauseMusic(obj);
            break;
        case "stop":
            stopMusic(obj);
            break;
        case "prevtime":
            timeChange(false);
            break;
        case "nexttime":
            timeChange(true);
            break;
        case "prevsong":
            songChange(false);
            break;
        case "nextsong":
            songChange(true);
            break;
        case "volM":
            volumeChange(3);
            break;
        case "volP":
            volumeChange(2);
            break;
        case "muted":
            setMuted(obj, audio.muted);
            break;
        //case "loop":
        //   loopSong();
        //   break;
        //case "random":
        //   randomSong();
        //   break;
        //case "allloop":
        //   allloopSong();
        //   break;
        case "loop":
        case "random":
        case "allloop":
            songStatus(obj);
            break;
        case "songbook":
            displayBook();
            break;
    }

}
//處理抓取div的歌
function drag(evt) {
    evt.dataTransfer.setData("text", evt.target.id);
    console.log(evt.target.id);
}
//處理允許丟入div的功能
function allowDrop(evt) {
    evt.preventDefault();
}
//處理丟入div的歌
function drop(evt, obj) {
    evt.preventDefault();
    var data = evt.dataTransfer.getData("text");
    obj.appendChild(document.getElementById(data));
}

//將歌本的歌讀進下拉選單中
function defaultSong() {
    for (i = 0; i < Sbook.children.length; i++) {
        var option = document.createElement("option");
        var Snode = Sbook.children[i];
        option.value = Snode.title;
        option.innerText = Snode.innerText;
        music.appendChild(option);

        Snode.draggable = true;
        Snode.id = "song" + (i + 1);
    }
    changeMusic(0);
}
//將時間從秒數轉換為幾分幾秒的格式
function getTimeFormat(timeSec) {
    min = Math.floor(timeSec / 60);
    sec = timeSec % 60;
    min = min < 10 ? "0" + min : min;
    sec = sec < 10 ? "0" + sec : sec;

    return min + ":" + sec;
}
//取得目前播放時間資訊
function getDuration() {
    songDuration = Math.round(audio.duration);
    songCurrentTime = Math.round(audio.currentTime);
    //將歌曲時間顯示在面板上
    duration.innerText = getTimeFormat(songCurrentTime) + " / " + getTimeFormat(songDuration);

    //餵值給進度Bar
    //progress.style.width = (audio.currentTime / audio.duration * 100) + "%";
    progress.max = audio.duration;
    progress.value = audio.currentTime;

    w = (audio.currentTime / audio.duration * 100) + "%";

    progress.style.backgroundImage = "-webkit-linear-gradient(left, #b00000, #b00000 "+w+" , #e4e4e4 "+w+", #e4e4e4)";

    //console.log(progress.style.width);
    if (songCurrentTime == songDuration) {
        console.log(songCurrentTime);
        console.log(songDuration);
        if (info2.innerText == "單曲循環") {
            index = music.selectedIndex;
            changeMusic(index);
        }
        else if (info2.innerText == "隨機播放") {
            index = Math.floor(Math.random() * music.options.length);
            changeMusic(index);
        }
        else if (info2.innerText == "" && music.selectedIndex == music.options.length - 1) {
            stopMusic(stop);
        }
        else
            songChange(true);
    }
    else
        setTimeout(getDuration, 1);
}
function showInfo(status) {
    switch (status) {
        case 1:
            info.innerText = "現正播放：" + song.title;
            break;
        case 2:
            info.innerText = "音樂暫停";
            break;
        case 3:
            info.innerText = "音樂停止";
            break;
    }

}

//////////////////////////////////////////////
//播放音樂
//audio.preload = "auto";
function playMusic(obj) {
    console.log(obj);
    obj.innerText = ";";
    obj.id = "pause";
    if (audio.currentTime == 0)
        audio.load();
    audio.play();
    showInfo(1);
    getDuration();
}
//暫停播放
function pauseMusic(obj) {
    console.log(obj);
    obj.innerText = "4";
    obj.id = "play";
    audio.pause();
    showInfo(2);
}
//停止播放
function stopMusic(obj) {
    pauseMusic(obj.previousElementSibling);
    audio.currentTime = 0;
    showInfo(3);
}
//快轉倒轉
function timeChange(flag) {
    if (flag)
        audio.currentTime += 10;
    else
        audio.currentTime -= 10;
}
//歌曲更換
function changeMusic(index) {
    song.src = music.options[index].value;
    song.title = music.options[index].innerText;
    music.options[index].selected = true;
    audio.currentTime = 0;
    if (audio.paused == false) {
        console.log(audio.paused);
        playMusic(music.nextElementSibling.nextElementSibling);
    }

    console.log(song.src);
}
//上一曲下一曲
function songChange(flag) {
    index = music.selectedIndex;
    len = music.options.length;
    if (flag) {
        if (index < len - 1)
            index++;
        else
            index = 0;
    }
    else {
        if (index > 0)
            index--;
        else
            index = len - 1;
    }
    console.log(index);
    changeMusic(index);
}

//音量設定
volumeChange(1);  //設定初始音量
function volumeChange(flag) {
    //console.log(audio.volume);
    if (flag == 2)
        vol.value++;
    else if (flag == 3)
        vol.value--;

    volValue.value = vol.value;
    audio.volume = volValue.value / 100;
    z = volValue.value + "%";
    vol.style.backgroundImage = "-webkit-linear-gradient(left, #009d72, #009d72 " + z + " , #e4e4e4 " + z + ", #e4e4e4)";

    //console.log(audio.volume);
}

//靜音設定
function setMuted(obj, status) {
    if (status) {
        audio.muted = false;
        //obj.style.textDecoration = "none";
        obj.className = "";
    }
    else {
        audio.muted = true;
        //obj.style.textDecoration = "line-through";
        obj.className = "lineThrough";

    }
}

//播放狀態判斷
function songStatus(obj) {
    if (obj.id == info2.title) {
        info2.innerText = "";
        info2.title = "";
    }
    else {
        switch (obj.id) {
            case "loop":
                info2.innerText = "單曲循環";
                break;
            case "random":
                info2.innerText = "隨機播放"
                break;
            case "allloop":
                info2.innerText = "全曲循環"
                break;
        }
        info2.title = obj.id;
    }

}

////單曲循環
//function loopSong() {
//    if (info2.innerText == "單曲循環")
//        info2.innerText = "";
//    else
//        info2.innerText = "單曲循環";
//}

////隨機播放
//function randomSong() {
//    if (info2.innerText == "隨機播放")
//        info2.innerText = "";
//    else
//        info2.innerText = "隨機播放";
//}

////全曲循環
//function allloopSong() {
//     if (info2.innerText == "全曲循環")
//        info2.innerText = "";
//    else
//        info2.innerText = "全曲循環";
//}

//跳到指定時間播放
function setTimeBar(evt) {
    //audio.currentTime = (evt.offsetX / ControlPanel.clientWidth) * audio.duration;
    audio.currentTime = progress.value;
    console.log(audio.currentTime);
    //audio.currentTime = 112.3
}
//更新歌本歌曲
function updateMusic() {
    for (let i = music.children.length - 1; i >= 0; i--) {
        music.removeChild(music.children[i]);
    }

    for (let i = 0; i < Tbook.children.length; i++) {
        var option = document.createElement("option");
        var Tnode = Tbook.children[i];
        option.value = Tnode.title;
        option.innerText = Tnode.innerText;
        music.appendChild(option);
    }
    changeMusic(0);
}
//顯示或隱藏歌本
function displayBook() {
    //alert(book.className == "hidden");
    if (book.className == "hidden")
        book.className = "";
    else
        book.className = "hidden";
}