import xml.etree.ElementTree as ET
import re
from pathlib import Path

def process_xml_line(line):
    # Find armor values in the line
    pattern = r'(body_armor|leg_armor|arm_armor)="(\d+)"'
    def double_value(match):
        attr, value = match.groups()
        return f'{attr}="{int(value) * 2}"'
    
    return re.sub(pattern, double_value, line)

def double_armor_values(input_path, output_path=None):
    # Create output path if not specified
    input_path = Path(input_path)
    if output_path is None:
        output_path = input_path.parent / f"{input_path.stem}_doubled{input_path.suffix}"
    
    # Process the file line by line to preserve formatting
    with open(input_path, 'r', encoding='utf-8') as infile:
        with open(output_path, 'w', encoding='utf-8', newline='') as outfile:
            for line in infile:
                modified_line = process_xml_line(line)
                outfile.write(modified_line)
    
    print(f"Modified XML saved to: {output_path}")

def main():
    input_file = "./example/body_armors.xml"
    
    try:
        double_armor_values(input_file)
        print("Armor values successfully doubled!")
    except FileNotFoundError:
        print(f"Error: Input file not found at {input_file}")
    except Exception as e:
        print(f"An error occurred: {str(e)}")

if __name__ == "__main__":
    main()