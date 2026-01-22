# Simple Flashcard Reader

Một phần mềm học từ vựng tối giản, giao diện Dark Mode, hỗ trợ đọc file text và thao tác nhanh bằng chuột hoặc bàn phím.

## 📁 Định dạng File yêu cầu

Chuẩn bị một file `.txt` (Notepad) với cấu trúc đan xen từng dòng:
* Dòng lẻ: Từ Tiếng Anh
* Dòng chẵn: Nghĩa Tiếng Việt
* *(Tùy chọn)* Trong thư mục ./Vocabulary/ có các ví dụ về file chuẩn.

**Ví dụ nội dung file `data.txt`:**
```text
Hello
Xin chào
Computer
Máy tính
Developer
Lập trình viên
Success
Thành công
```

## 🚀 Cách sử dụng

1. Mở ứng dụng. (./FlashCardReader/bin/Release/.exe)
2. Trên thanh Menu, chọn **File -> Open**.
3. Tìm và chọn file `.txt` dữ liệu của bạn.
4. *(Tùy chọn)* Chọn **File -> Shuffle** để xáo trộn ngẫu nhiên danh sách từ vựng (ID gốc của từ vẫn được giữ nguyên để theo dõi).

## 🎮 Thao tác điều khiển (Controls)
Ứng dụng hỗ trợ thao tác song song cả hai tay để tối ưu tốc độ học:

1. Xem nghĩa (Lật thẻ Anh <-> Việt)
Chuột: Bấm Chuột Trái (Left Click).
Bàn phím: Phím Space (Cách), Mũi tên Lên, hoặc Mũi tên Xuống.

2. Chuyển từ tiếp theo (Next)
Chuột: Bấm Chuột Phải (Right Click).
Bàn phím: Phím Enter, hoặc Mũi tên Phải.

3. Quay lại từ trước (Back)
Bàn phím: Mũi tên Trái.