'Brainfuck String Generator'

def generate_path(input_string: str, max_branch_distance: int):
    'Generate string path'
    branch_list = []
    sequence = []
    for input_char in input_string:
        min_branch_distance = max_branch_distance
        closest_branch = None
        for branch_head in enumerate(branch[-1] for branch in branch_list):
            branch_distance = abs(branch_head[1] - ord(input_char))
            if branch_distance < min_branch_distance:
                closest_branch = branch_head[0]
        if closest_branch:
            sequence.append(closest_branch)
            branch_list[closest_branch].append(ord(input_char))
        else:
            sequence.append(len(branch_list))
            branch_list.append([ord(input_char)])
    return (branch_list, tuple(sequence))

def shift_by(num: int):
    'Return shift string'
    if not num:
        return ''
    return '>' * num if num > 0 else '<' * -num

def change_by(num: int):
    'Return increment/decrement string'
    if not num:
        return ''
    return '+' * num if num > 0 else '-' * -num

def generate_code(input_string: str, max_branch_distance: int):
    'Generate Brainfuck source code'
    final_code = '++++++++++['
    appr = []
    branches, seq = generate_path(input_string, max_branch_distance)
    for branch in branches:
        coefficient = round(branch[0] / 10)
        final_code += ">" + change_by(coefficient)
        appr.append(coefficient * 10)
    final_code += shift_by(-len(branches)) + '-]>'
    indexes = [0] * len(branches)
    for step, branch_index in enumerate(seq):
        index = indexes[branch_index]
        branch = branches[branch_index]
        if step > 0:
            final_code += shift_by(branch_index - seq[step - 1])
        if index > 0:
            final_code += change_by(branch[index] - branch[index - 1])
        else:
            final_code += change_by(branch[0] - appr[branch_index])
        indexes[branch_index] += 1
        final_code += '.'
    return final_code
