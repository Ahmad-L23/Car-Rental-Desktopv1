<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<title>Image Gallery</title>
<style>
  body {
    font-family: Arial, sans-serif;
    background: #f5f5f5;
    margin: 0; padding: 20px;
  }
  h1 {
    text-align: center;
    margin-bottom: 30px;
  }
  .gallery {
    display: flex;
    flex-wrap: wrap;
    gap: 16px;
    justify-content: center;
  }
  .gallery img {
    max-width: 250px;
    height: auto;
    border-radius: 8px;
    box-shadow: 0 2px 6px rgba(0,0,0,0.15);
    cursor: pointer;
    transition: transform 0.2s ease;
  }
  .gallery img:hover {
    transform: scale(1.05);
  }

  /* Optional: Lightbox modal */
  .lightbox {
    display: none;
    position: fixed;
    z-index: 9999;
    top: 0; left: 0; right: 0; bottom: 0;
    background: rgba(0,0,0,0.8);
    justify-content: center;
    align-items: center;
  }
  .lightbox img {
    max-width: 90vw;
    max-height: 90vh;
    border-radius: 10px;
    box-shadow: 0 0 15px #fff;
  }
  .lightbox:target {
    display: flex;
  }
</style>
</head>
<body>

<h1>Project Image Gallery</h1>

<div class="gallery">
  <a href="#img1"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (1).jpeg" alt="Image 1"></a>
  <a href="#img2"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (2).jpeg" alt="Image 2"></a>
  <a href="#img3"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (3).jpeg" alt="Image 3"></a>
  <a href="#img4"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (4).jpeg" alt="Image 4"></a>
  <a href="#img5"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (5).jpeg" alt="Image 5"></a>
  <a href="#img6"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (6).jpeg" alt="Image 6"></a>
  <a href="#img7"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (7).jpeg" alt="Image 7"></a>
  <a href="#img8"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (8).jpeg" alt="Image 8"></a>
  <a href="#img9"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (9).jpeg" alt="Image 9"></a>
  <a href="#img10"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM.jpeg" alt="Image 10"></a>
  <a href="#img11"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (1).jpeg" alt="Image 11"></a>
  <a href="#img12"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (2).jpeg" alt="Image 12"></a>
  <a href="#img13"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (3).jpeg" alt="Image 13"></a>
  <a href="#img14"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (4).jpeg" alt="Image 14"></a>
  <a href="#img15"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (5).jpeg" alt="Image 15"></a>
  <a href="#img16"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (6).jpeg" alt="Image 16"></a>
  <a href="#img17"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (7).jpeg" alt="Image 17"></a>
  <a href="#img18"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM.jpeg" alt="Image 18"></a>
</div>

<!-- Lightbox modal for each image -->
<div id="img1" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (1).jpeg" alt="Image 1"></a></div>
<div id="img2" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (2).jpeg" alt="Image 2"></a></div>
<div id="img3" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (3).jpeg" alt="Image 3"></a></div>
<div id="img4" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (4).jpeg" alt="Image 4"></a></div>
<div id="img5" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (5).jpeg" alt="Image 5"></a></div>
<div id="img6" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (6).jpeg" alt="Image 6"></a></div>
<div id="img7" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (7).jpeg" alt="Image 7"></a></div>
<div id="img8" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (8).jpeg" alt="Image 8"></a></div>
<div id="img9" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (9).jpeg" alt="Image 9"></a></div>
<div id="img10" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.21 PM.jpeg" alt="Image 10"></a></div>
<div id="img11" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (1).jpeg" alt="Image 11"></a></div>
<div id="img12" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (2).jpeg" alt="Image 12"></a></div>
<div id="img13" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (3).jpeg" alt="Image 13"></a></div>
<div id="img14" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (4).jpeg" alt="Image 14"></a></div>
<div id="img15" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (5).jpeg" alt="Image 15"></a></div>
<div id="img16" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (6).jpeg" alt="Image 16"></a></div>
<div id="img17" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (7).jpeg" alt="Image 17"></a></div>
<div id="img18" class="lightbox"><a href="#"><img src="WhatsApp Image 2025-12-04 at 3.38.20 PM.jpeg" alt="Image 18"></a></div>

</body>
</html>
