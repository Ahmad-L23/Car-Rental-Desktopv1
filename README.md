<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<title>WhatsApp Images Carousel</title>
<style>
  body {
    font-family: Arial, sans-serif;
    background: #f9f9f9;
    display: flex; 
    justify-content: center; 
    align-items: center; 
    height: 100vh;
    margin: 0;
  }
  .carousel {
    position: relative;
    max-width: 600px;
    width: 90vw;
    background: white;
    border-radius: 10px;
    box-shadow: 0 0 15px rgba(0,0,0,0.2);
    overflow: hidden;
  }
  .carousel img {
    width: 100%;
    display: none;
  }
  .carousel img.active {
    display: block;
  }
  .nav-btn {
    position: absolute;
    top: 50%;
    transform: translateY(-50%);
    background: rgba(0,0,0,0.5);
    border: none;
    color: white;
    font-size: 2rem;
    padding: 0 15px;
    cursor: pointer;
    user-select: none;
    border-radius: 50%;
  }
  .nav-btn:hover {
    background: rgba(0,0,0,0.8);
  }
  #prevBtn {
    left: 10px;
  }
  #nextBtn {
    right: 10px;
  }
</style>
</head>
<body>

<div class="carousel">
  <button class="nav-btn" id="prevBtn">&#8592;</button>
  <button class="nav-btn" id="nextBtn">&#8594;</button>

  <img src="WhatsApp Image 2025-12-04 at 3.38.21 PM.jpeg" alt="Image 1" class="active" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (1).jpeg" alt="Image 2" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (2).jpeg" alt="Image 3" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (3).jpeg" alt="Image 4" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (4).jpeg" alt="Image 5" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (5).jpeg" alt="Image 6" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (6).jpeg" alt="Image 7" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (7).jpeg" alt="Image 8" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (8).jpeg" alt="Image 9" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.21 PM (9).jpeg" alt="Image 10" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.20 PM.jpeg" alt="Image 11" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (1).jpeg" alt="Image 12" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (2).jpeg" alt="Image 13" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (3).jpeg" alt="Image 14" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (4).jpeg" alt="Image 15" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (5).jpeg" alt="Image 16" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (6).jpeg" alt="Image 17" />
  <img src="WhatsApp Image 2025-12-04 at 3.38.20 PM (7).jpeg" alt="Image 18" />
</div>

<script>
  const images = document.querySelectorAll('.carousel img');
  let currentIndex = 0;

  const showImage = (index) => {
    images.forEach(img => img.classList.remove('active'));
    images[index].classList.add('active');
  };

  document.getElementById('prevBtn').addEventListener('click', () => {
    currentIndex = (currentIndex - 1 + images.length) % images.length;
    showImage(currentIndex);
  });

  document.getElementById('nextBtn').addEventListener('click', () => {
    currentIndex = (currentIndex + 1) % images.length;
    showImage(currentIndex);
  });
</script>

</body>
</html>
