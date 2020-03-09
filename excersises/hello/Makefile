CSFLAGS = -optimize+ - platform:arm
.PHONEY:all
all: out.txt
	cat out.txt

out.txt : main.exe
	mono main.exe > out.txt
main.exe : main.cs
	mcs $(CSFALGS) -out:main.exe main.cs

clean: 
	rm --force out.txt main.exe

