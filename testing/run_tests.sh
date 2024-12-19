#!/bin/bash

# Set the PYTHONPATH to include the backend/src directory
export PYTHONPATH=$PYTHONPATH:$(pwd)/backend

# Run the unit tests
python3 -m unittest discover -s testing/unit -p "*.py"
