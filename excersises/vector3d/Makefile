CSC = mcs
all : out.txt
	cat out.txt
out.txt : main.exe
	mono main.exe > out.txt
main.exe :  main.cs vec3d.dll
	$(CSC) -reference:$(word 2,$^) $<
vec3d.dll : vec3d.cs
	$(CSC) -target:library -out:$@ $<

