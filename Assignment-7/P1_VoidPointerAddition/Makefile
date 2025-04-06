# Compiler Specifications
CXX = g++
CXXFLAGS = -Wall -std=c++11

# Target, source, executable and object files directory
TARGET = bin/VoidPointerAddition
BUILDDIR = build
BINDIR = bin

# Source and object file
SRCS = main.cpp
OBJS = $(patsubst $(SRCS), $(BUILDDIR)/main.o, $(SRCS)) 

# Rule to build and run the executable
all: $(TARGET) run

# Rule to link the object files to build the executable
$(TARGET): $(OBJS)
		@mkdir -p $(BINDIR)
		$(CXX) $(CXXFLAGS) -o $(TARGET) $^

# Rule to build the object files from the cpp files
$(BUILDDIR)/%.o: main.cpp
		@mkdir -p $(BUILDDIR)
		$(CXX) $(CXXFLAGS) -c $< -o $@

# Rule to run the executable
run: $(TARGET)
		./$(TARGET)

# Rule to delete the generated files
clean:
		rm -rf $(TARGET).exe $(BUILDDIR)/*.o

# Rule to ignore certain keyword files
.PHONY: all clean run