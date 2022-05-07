// Based on https://github.com/mdn/samples-server/blob/master/s/webrtc-capturestill/capture.js

var interopJS = interopJS || {}

let video = null;
let canvas = null;
let context = null;
let photo = null;
let streaming = false;

let width = 100;    // We will scale the photo width to this
let height = 0;     // This will be computed based on the input stream

export function startVideo(options) {
    video = document.getElementById(options.videoId);
    canvas = document.getElementById(options.canvasId);
    photo = document.getElementById(options.photoId);
    context = canvas.getContext('2d');
    width = options.width;

    navigator.mediaDevices.getUserMedia({ video: true, audio: false })
        .then(function (stream) {
            video.srcObject = stream;
            video.play();
        })
        .catch(function (err) {
            console.log("An error occurred: " + err);
        });

    video.addEventListener('canplay', function () {
        if (!streaming) {
            height = video.videoHeight / (video.videoWidth / width);

            if (isNaN(height)) {
                height = width / (4 / 3);
            }

            video.setAttribute('width', width);
            video.setAttribute('height', height);
            canvas.setAttribute('width', width);
            canvas.setAttribute('height', height);

            streaming = true;
        }
    }, false);

    clearPicture();
}

export function clearPicture() {
    var context = canvas.getContext('2d');
    context.fillStyle = "#FFF";
    context.fillRect(0, 0, canvas.width, canvas.height);

    var data = canvas.toDataURL('image/png');
    photo.setAttribute('src', data);
}

export function takePicture() {
    var context = canvas.getContext('2d');

    if (width && height) {
        canvas.width = width;
        canvas.height = height;

        context.drawImage(video, 0, 0, width, height);

        var data = canvas.toDataURL('image/png');
        photo.setAttribute('src', data);
    } else {
        clearPicture();
    }
}
