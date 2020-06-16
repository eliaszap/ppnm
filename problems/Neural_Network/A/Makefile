all: plot.svg

plot.svg: plot.gpi fitdata.txt fitdata.txt
	gnuplot $<
out.txt xydata.txt fitdata.txt: main.exe
	mono $<

main.exe: main.cs nn.dll
	mcs $< -reference:nn.dll $<

MATLIB = ../../matlib/
S := $(MATLIB)/matrix/vector.cs
S += $(MATLIB)/matrix/matrix.cs
S += ../../Minimization/minimization.cs

nn.dll: ../nn.cs $(S)
	mcs -target:library -out:$@ $^

clean:
		rm -f out.txt fitdata.txt xydata.txt *.exe *.dll *.svg