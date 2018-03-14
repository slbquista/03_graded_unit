-- Production > Insert

INSERT INTO gu_batch (drink_id, gyle, container_id, number_of_items, storage_location)
VALUES (insertAlcohol, insertGyle, insertContainer, insertNumberContainers, insertLocation);
-- drink_id should be displayed as drink_type and container_id should be displayed as container


-- Packaging > Bottle

UPDATE gu_batch
SET container_id = updateContainer, number_of_items = updateNumberContainers, date_filled = updateDate, storage_location = updateLocationBottle
WHERE gyle = selectGyleBottle;
-- container_id should be displayed as container

-- Packaging > Label

UPDATE gu_batch
SET packaged = updatePackaged, storage_location = updateLocationLabel
WHERE gyle = selectGyleLabel

INSERT INTO gu_duty
VALUES (selectGyleLabel, setStaffID, setStartNumber, setEndNumber, setDutyStatus);


-- Sales > Sell
DELETE FROM gu_batch
WHERE gyle = selectGyleSell and storage_location = 'Cage' and packaged = 'Y';

