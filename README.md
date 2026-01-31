# 42 Kocaeli Unity Piscine
## Module 00 - Floor is Lava (Zemin Lav)

Bu proje, 42 Okulu Unity Piscine eğitiminin ilk modülüdür. Unity oyun motorunun temel mekaniklerini, karakter kontrolü, kamera sistemi, fizik simülasyonu ve materyal manipülasyonu konularını öğrenmek için tasarlanmış bir "Floor is Lava" oyunudur.

## 🎮 Proje Hakkında

**Floor is Lava**, oyuncunun yükselen lav platformlarından kaçarak hayatta kalmaya çalıştığı bir 3D platform oyunudur. Oyuncu karakteri WASD tuşları ile hareket ettirir, Space tuşu ile zıplar ve ok tuşları ile kamerayı döndürür.

## 📚 Scripts (Betikler)

### PlayerController.cs
**Dosya:** `Assets/Scripts/PlayerController.cs`

Oyuncu karakterinin hareket ve zıplama mekaniklerini kontrol eden ana script.

- **Sınıf:** `PlayerController : MonoBehaviour`
- **Public Değişkenler:**
  - `speed` (float): Hareket hızı (varsayılan: 10f)
  - `jumpForce` (float): Zıplama kuvveti (varsayılan: 5f)
  - `groundCheckDistance` (float): Zemin kontrol mesafesi (varsayılan: 0.1f)
  - `cameraTransform` (Transform): Kamera referansı
  - `groundLayer` (LayerMask): Zemin layer'ı

- **Özellikler:**
  - **Hareket Sistemi**: WASD tuşları ile kameraya göre relatif hareket
  - **Zıplama Mekanizmi**: Raycast ile zemin kontrolü ve Space tuşu ile zıplama
  - **Fizik Tabanlı**: Rigidbody kullanarak gerçekçi fizik simülasyonu
  - **Lav Çarpışma**: Trigger collision ile oyun sonu kontrolü

- **Fonksiyonlar:**
  ```csharp
  void Start()              // Rigidbody ve kamera başlatma
  void Update()             // Zemin kontrolü ve zıplama inputu
  void FixedUpdate()        // Fizik bazlı hareket hesaplamaları
  void OnTriggerEnter()     // Lav ile çarpışma kontrolü
  ```

### CameraOrbitController.cs
**Dosya:** `Assets/Scripts/CameraController.cs`

Oyuncu etrafında orbital kamera hareketi sağlayan script.

- **Sınıf:** `CameraOrbitController : MonoBehaviour`
- **Public Değişkenler:**
  - `target` (Transform): Takip edilecek hedef (oyuncu)
  - `distance` (float): Hedefe olan mesafe (varsayılan: 7f)
  - `height` (float): Kamera yüksekliği (varsayılan: 4f)
  - `rotationSpeed` (float): Dönüş hızı (varsayılan: 90f)

- **Özellikler:**
  - **Orbital Hareket**: Hedef etrafında dairesel hareket
  - **Manuel Kontrol**: Sol/Sağ ok tuşları ile kamera döndürme
  - **Smooth Tracking**: Her frame'de hedefe bakış açısı güncelleme
  - **Trigonometrik Hesaplama**: Sin/Cos kullanarak dairesel pozisyon

- **Fonksiyonlar:**
  ```csharp
  void LateUpdate()         // Karakter hareketi sonrası kamera güncelleme
  ```

### LavaScroll.cs
**Dosya:** `Assets/Scripts/LavaScroll.cs`

Lav materyalinin texture'ını hareket ettirerek animasyon efekti oluşturan script.

- **Sınıf:** `LavaScroll : MonoBehaviour`
- **Public Değişkenler:**
  - `speedY` (float): Texture kayma hızı (varsayılan: 0.05f)

- **Özellikler:**
  - **Texture Offset**: Material'in mainTextureOffset'ini güncelleme
  - **Time-based Animation**: Time.time kullanarak sürekli hareket
  - **Vertical Scroll**: Y ekseninde kayma efekti

- **Fonksiyonlar:**
  ```csharp
  void Start()              // Renderer component referansı alma
  void Update()             // Her frame'de texture offset güncelleme
  ```

## 🎨 Assets (Varlıklar)

### Materials (Materyaller)
- **Stone_Base_Color.mat**: Platformlar için taş materyali
- **Vol_35_3_Base_Color.mat**: Duvarlar için materyal
- **Vol_36_5_Water_Base_Color.mat**: Lav için su/lav materyali

### Textures (Dokular)
- **Stone_Base_Color.png**: Taş platform dokusu
- **Vol_35_3_Base_Color.tga**: Duvar dokusu
- **Vol_36_5_Water_Base_Color.png**: Lav dokusu

### Scenes (Sahneler)
- **FloorIsLavaScene.unity**: Ana oyun sahnesi

## 🔧 Kurulum ve Kullanım

### Unity Kurulumu
```bash
# Unity Hub'ı indirin
https://unity.com/download

# Proje için gerekli Unity versiyonu
Unity 2022.3.62f3 LTS
```

### Projeyi Açma
1. Unity Hub'ı açın
2. "Open" butonuna tıklayın
3. `unityModule00/Module00` klasörünü seçin
4. Unity Editor'de proje açılacaktır

### Oyunu Çalıştırma
1. Unity Editor'de `Assets/Scenes/FloorIsLavaScene.unity` sahnesini açın
2. Play butonuna basın (veya Ctrl+P)
3. Oyunu test edin:
   - **WASD**: Hareket
   - **Space**: Zıplama
   - **Sol/Sağ Ok**: Kamera döndürme

### Build Alma
```bash
# Unity Editor'de
File > Build Settings
# Platform seçin (PC, Mac & Linux Standalone)
# Build butonuna tıklayın
```

## 🎯 Öğrenilen Kavramlar

1. **Unity Component Sistemi**: MonoBehaviour, Transform, Rigidbody
2. **Input Management**: Input.GetKey, Input.GetKeyDown kullanımı
3. **Physics System**: Raycast, Rigidbody, Collision/Trigger sistemleri
4. **Camera Control**: LateUpdate, Transform manipülasyonu, LookAt fonksiyonu
5. **Material & Texture**: Renderer, Material.mainTextureOffset
6. **Vector Mathematics**: Vector3 hesaplamaları, normalization, trigonometri
7. **Game Loop**: Start, Update, FixedUpdate, LateUpdate lifecycle metodları
8. **LayerMask Kullanımı**: Spesifik layer'larda raycast kontrolü

## 🎮 Oyun Mekanikleri

### Hareket Sistemi
- Kameraya göre relatif hareket (forward/right vektörleri)
- Horizontal velocity limiti (maksimum 6 m/s)
- ForceMode.Force ile sürekli kuvvet uygulanması

### Zıplama Sistemi
- Raycast ile zemin kontrolü
- Sadece yerdeyken zıplama izni
- ForceMode.Impulse ile anlık kuvvet

### Kamera Sistemi
- Orbital camera pattern
- Smooth target following
- Manual rotation control

### Lav Mekanizmi
- Trigger collision detection
- Game Over sistemi
- Animated texture scrolling

## 📋 Teknik Detaylar

### Proje Yapısı
```
Module00/
├── Assets/
│   ├── Materials/        # 3D materyal dosyaları
│   ├── Scenes/          # Unity sahne dosyaları
│   ├── Scripts/         # C# script dosyaları
│   ├── Textures/        # Texture image dosyaları
│   └── Resources/       # Runtime resources
├── Packages/            # Unity package dependencies
└── ProjectSettings/     # Proje ayarları
```

### Kullanılan Unity Komponentleri
- **Rigidbody**: Fizik simülasyonu
- **Collider**: Çarpışma tespiti (Box, Sphere, Mesh)
- **Renderer**: Materyal ve texture rendering
- **Transform**: Pozisyon, rotasyon, scale
- **Camera**: Görüntü render sistemi

### Kod Prensipler
- **Single Responsibility**: Her script tek bir sorumluluğa sahip
- **Component-Based Design**: Unity'nin ECS yaklaşımı
- **Physics-Based Movement**: ForceMode ile gerçekçi hareket
- **Frame-Independent Update**: Time.deltaTime kullanımı

## 📝 Notlar

- Tüm scriptler C# ile yazılmıştır
- Unity'nin component-based architecture'ı takip edilmiştir
- Physics-based movement tercih edilmiştir (CharacterController yerine Rigidbody)
- LateUpdate kullanarak kamera-karakter senkronizasyonu sağlanmıştır
- Trigger collider'lar ile performans optimize edilmiştir
- Material instance yerine shared material kullanılarak memory optimize edilmiştir

