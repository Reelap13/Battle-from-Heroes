using System.Collections.Generic;
using UnityEngine;

public class GameBoard
{
    private GameBoardController _controller;
    private Dictionary<KeyValuePair<int, int>, Field> _board;
    public GameBoard(GameBoardController controller)
    {
        _controller = controller;
        _board = new Dictionary<KeyValuePair<int, int>, Field>();
    }

    public void CreateFields()
    {
        for (int line = 0; line < _controller.Weith; line++)
        {
            int tiltSide = - line / 2; 
            for (int row = tiltSide; row < _controller.Length + tiltSide; row++)
            {
                GameObject fieldObject = _controller.CreateField();
                var indexes = new KeyValuePair<int, int>(row, line);

                fieldObject.transform.position = _controller.BoardStartingPoint +
                    _controller.Vector.Right * row +
                    _controller.Vector.RightDown * line;
                fieldObject.transform.parent = _controller.Transform;

                Field field = fieldObject.GetComponent<Field>();
                field.setPreset(indexes);
                _board.Add(indexes, field);
            }
        }
    }

    public LinkedList<Field> FindAllAvailableFieldsToAttack(KeyValuePair<int, int> startingIndexes, int movement, int attackDistance, int teamId)
    {
        LinkedList<Field> availableField = new LinkedList<Field>();
        LinkedList<Field> allDeletedFields = FindForAllDeletedFieldsByWayLength(startingIndexes, movement + attackDistance);
        foreach (var field in allDeletedFields)
            if (!field.IsFree && field.Pack.TeamId != teamId)
                availableField.AddLast(field);

        return availableField;
    }

    public LinkedList<Field> FindAllAvailableFieldsToMove(KeyValuePair<int, int> startingIndexes, int movement)
    {
        LinkedList<Field> availableField = new LinkedList<Field>();
        LinkedList<Field> allDeletedFields = FindForAllDeletedFieldsByWayLength(startingIndexes, movement);
        foreach (var field in allDeletedFields)
            if (field.IsFree) 
                availableField.AddLast(field);

        return availableField;
    }

    public LinkedList<Field> FindForAllDeletedFieldsByWayLength(KeyValuePair<int, int> startingIndexes, int maxLength)
    {
        LinkedList<Field> availableFields = new LinkedList<Field>();

        Dictionary<KeyValuePair<int, int>, int> findedField = new Dictionary<KeyValuePair<int, int>, int>(); 
        Queue<KeyValuePair<int, int>> fieldsIndexesUnderConsideration = new Queue<KeyValuePair<int, int>>();
        fieldsIndexesUnderConsideration.Enqueue(startingIndexes);
        findedField.Add(startingIndexes, 0);

        KeyValuePair<int, int> fieldIndexes;
        while (fieldsIndexesUnderConsideration.TryDequeue(out fieldIndexes))
        {
            int wayLength = findedField[fieldIndexes];
            if (wayLength > maxLength - 1)
                continue;

            foreach (var field in GetAllNearesFields(fieldIndexes))
            {
                if (!field.IsFree)
                {
                    availableFields.AddLast(field);
                    continue;
                }

                if (!findedField.ContainsKey(field.Indexes))
                {
                    findedField.Add(field.Indexes, wayLength + 1);
                    availableFields.AddLast(field);
                    fieldsIndexesUnderConsideration.Enqueue(field.Indexes);
                }
            }
        }

        return availableFields;
    }

    public LinkedList<Field> FindTheShortestWayFromFieldToField(
        KeyValuePair<int, int> startingIndexes, 
        KeyValuePair<int, int> finishingIndexes)
    {
        LinkedList<Field> RestorePath(
            Dictionary<KeyValuePair<int, int>, int> findedField, 
            KeyValuePair<int, int> finishingIndexes)
        {
            LinkedList<Field> availableFields = new LinkedList<Field>();
            var currentField = finishingIndexes;
            while (findedField[currentField] != 0)
            {
                availableFields.AddFirst(_board[currentField]);
                int wayLength = findedField[currentField];
                foreach (var field in GetAllNearesFields(currentField))
                {
                    if (findedField.ContainsKey(field.Indexes) && findedField[field.Indexes] <= wayLength - 1)
                    {
                        currentField = field.Indexes;
                        break;
                    }
                }
            }
            availableFields.AddFirst(_board[currentField]);

            return availableFields;
        }


        Dictionary<KeyValuePair<int, int>, int> findedField = new Dictionary<KeyValuePair<int, int>, int>();
        Queue<KeyValuePair<int, int>> fieldsIndexesUnderConsideration = new Queue<KeyValuePair<int, int>>();
        fieldsIndexesUnderConsideration.Enqueue(startingIndexes);
        findedField.Add(startingIndexes, 0);

        KeyValuePair<int, int> fieldIndexes;
        while (fieldsIndexesUnderConsideration.TryDequeue(out fieldIndexes))
        {
            int wayLength = findedField[fieldIndexes];

            foreach (var field in GetAllNearesFields(fieldIndexes))
            {
                if (!findedField.ContainsKey(field.Indexes))
                {
                    findedField.Add(field.Indexes, wayLength + 1);

                    if (field.Indexes.Key == finishingIndexes.Key &&
                        field.Indexes.Value == finishingIndexes.Value)
                        return RestorePath(findedField, finishingIndexes);

                    fieldsIndexesUnderConsideration.Enqueue(field.Indexes);
                }
            }
        }
        return null;
    }

    public LinkedList<Field> GetLeftSide()
    {
        return GetVerticalLine(0);
    }

    public LinkedList<Field> GetRightSide()
    {
        return GetVerticalLine(_controller.Length - 1);
    }

    private LinkedList<Field> GetVerticalLine(int startingRow)
    {
        LinkedList<Field> availableFields = new LinkedList<Field>();

        for (int line = 0; line < _controller.Weith; line++)
        {
            int tiltSide = -line / 2;
            int row = tiltSide + startingRow;

            Field field;
            if (_board.TryGetValue( new KeyValuePair<int, int>(row, line), out field))
                availableFields.AddLast(field);
        }

        return availableFields;
    }

    public LinkedList<Field> GetAllNearesFields(KeyValuePair<int, int> startingIndexes)
    {
        void AddFieldIfExist(LinkedList<Field> fields, int row, int line)
        {
            Field field = null;
            _board.TryGetValue(new KeyValuePair<int, int>(row, line), out field);
            if (field != null) { fields.AddLast(field); }
        }

        LinkedList<Field> availableFields = new LinkedList<Field>();
        AddFieldIfExist(availableFields, startingIndexes.Key, startingIndexes.Value - 1);
        AddFieldIfExist(availableFields, startingIndexes.Key, startingIndexes.Value + 1);

        AddFieldIfExist(availableFields, startingIndexes.Key + 1, startingIndexes.Value - 1);
        AddFieldIfExist(availableFields, startingIndexes.Key - 1, startingIndexes.Value + 1);

        AddFieldIfExist(availableFields, startingIndexes.Key + 1, startingIndexes.Value);
        AddFieldIfExist(availableFields, startingIndexes.Key - 1, startingIndexes.Value);

        return availableFields;
    }
}
