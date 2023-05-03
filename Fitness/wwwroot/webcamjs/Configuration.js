function ready() {
    if (document.readyState == 'complete') {
        Webcam.set({
            with: 280,
            height: 280,
            image_format: 'jpeg',
            jpeg_quality: 90
        });
        try {
            Webcam.attach('#camera');
        } catch (e) {
            alert(e);
        }
    }
}
function take_snapshot() {
    var data = null;
    Webcam.snap(function (data_uri) {
        data = data_uri;
    });
    return data;
}